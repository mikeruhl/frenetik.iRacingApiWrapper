﻿using System.Collections;
using System.Text.Json;

namespace Frenetik.iRacingApiWrapper.JsonConverters;


/// <summary>
/// Json Converter
/// </summary>
/// <typeparam name="TItem"></typeparam>
/// <remarks>Credit to answer from <see href="https://stackoverflow.com/questions/59430728/how-to-handle-both-a-single-item-and-an-array-for-the-same-property-using-system"/></remarks>
public class SingleOrArrayConverter<TItem> : SingleOrArrayConverter<List<TItem>, TItem>
{
    public SingleOrArrayConverter() : this(true) { }
    public SingleOrArrayConverter(bool canWrite) : base(canWrite) { }
}

public class SingleOrArrayConverterFactory : JsonConverterFactory
{
    public bool CanWrite { get; }

    public SingleOrArrayConverterFactory() : this(true) { }

    public SingleOrArrayConverterFactory(bool canWrite) => CanWrite = canWrite;

    public override bool CanConvert(Type typeToConvert)
    {
        var itemType = GetItemType(typeToConvert);
        if (itemType == null)
            return false;
        if (itemType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(itemType))
            return false;
        if (typeToConvert.GetConstructor(Type.EmptyTypes) == null || typeToConvert.IsValueType)
            return false;
        return true;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var itemType = GetItemType(typeToConvert) ?? throw new InvalidOperationException($"Could not get item type for: {typeToConvert.GetType().Name}");
        var converterType = typeof(SingleOrArrayConverter<,>).MakeGenericType(typeToConvert, itemType);
        return Activator.CreateInstance(converterType, new object[] { CanWrite }) as JsonConverter ?? throw new InvalidOperationException($"No Converter for type found: {typeToConvert.GetType().Name}");
    }

    static Type? GetItemType(Type type)
    {
        // Quick reject for performance
        if (type.IsPrimitive || type.IsArray || type == typeof(string))
            return null;
        while (type != null)
        {
            if (type.IsGenericType)
            {
                var genType = type.GetGenericTypeDefinition();
                if (genType == typeof(List<>))
                    return type.GetGenericArguments()[0];
                // Add here other generic collection types as required, e.g. HashSet<> or ObservableCollection<> or etc.
            }
            type = type.BaseType!;
        }
        return null;
    }
}

public class SingleOrArrayConverter<TCollection, TItem> : JsonConverter<TCollection> where TCollection : class, ICollection<TItem>, new()
{
    public SingleOrArrayConverter() : this(true) { }
    public SingleOrArrayConverter(bool canWrite) => CanWrite = canWrite;

    public bool CanWrite { get; }

    public override TCollection? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.StartArray:
                var list = new TCollection();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray)
                        break;
                    list.Add(JsonSerializer.Deserialize<TItem>(ref reader, options)!);
                }
                return list;
            default:
                return new TCollection { JsonSerializer.Deserialize<TItem>(ref reader, options)! };
        }
    }

    public override void Write(Utf8JsonWriter writer, TCollection value, JsonSerializerOptions options)
    {
        if (CanWrite && value.Count == 1)
        {
            JsonSerializer.Serialize(writer, value.First(), options);
        }
        else
        {
            writer.WriteStartArray();
            foreach (var item in value)
                JsonSerializer.Serialize(writer, item, options);
            writer.WriteEndArray();
        }
    }
}