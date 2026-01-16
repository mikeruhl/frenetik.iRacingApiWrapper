using System.Collections;
using System.Text.Json;

namespace Frenetik.iRacingApiWrapper.JsonConverters;


/// <summary>
/// Converts JSON property that can be either a single item or an array to a list.
/// </summary>
/// <typeparam name="TItem">Type of items in the collection.</typeparam>
/// <remarks>Credit to answer from <see href="https://stackoverflow.com/questions/59430728/how-to-handle-both-a-single-item-and-an-array-for-the-same-property-using-system"/></remarks>
public class SingleOrArrayConverter<TItem> : SingleOrArrayConverter<List<TItem>, TItem>
{
    /// <summary>
    /// Initializes a new instance with writing enabled.
    /// </summary>
    public SingleOrArrayConverter() : this(true) { }
    /// <summary>
    /// Initializes a new instance with specified write capability.
    /// </summary>
    /// <param name="canWrite">Whether the converter can write single items as non-array values.</param>
    public SingleOrArrayConverter(bool canWrite) : base(canWrite) { }
}

/// <summary>
/// Factory for creating SingleOrArrayConverter instances.
/// </summary>
public class SingleOrArrayConverterFactory : JsonConverterFactory
{
    /// <summary>
    /// Gets whether the converter can write single items as non-array values.
    /// </summary>
    public bool CanWrite { get; }

    /// <summary>
    /// Initializes a new instance with writing enabled.
    /// </summary>
    public SingleOrArrayConverterFactory() : this(true) { }

    /// <summary>
    /// Initializes a new instance with specified write capability.
    /// </summary>
    /// <param name="canWrite">Whether the converter can write single items as non-array values.</param>
    public SingleOrArrayConverterFactory(bool canWrite) => CanWrite = canWrite;

    /// <summary>
    /// Determines whether this converter can convert the specified type.
    /// </summary>
    /// <param name="typeToConvert">Type to check for conversion support.</param>
    /// <returns>True if the type can be converted.</returns>
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

    /// <summary>
    /// Creates a converter instance for the specified type.
    /// </summary>
    /// <param name="typeToConvert">Type to create converter for.</param>
    /// <param name="options">JSON serializer options.</param>
    /// <returns>A configured converter instance.</returns>
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

/// <summary>
/// Converts JSON property that can be either a single item or an array to a collection.
/// </summary>
/// <typeparam name="TCollection">Collection type to deserialize into.</typeparam>
/// <typeparam name="TItem">Type of items in the collection.</typeparam>
public class SingleOrArrayConverter<TCollection, TItem> : JsonConverter<TCollection> where TCollection : class, ICollection<TItem>, new()
{
    /// <summary>
    /// Initializes a new instance with writing enabled.
    /// </summary>
    public SingleOrArrayConverter() : this(true) { }
    /// <summary>
    /// Initializes a new instance with specified write capability.
    /// </summary>
    /// <param name="canWrite">Whether the converter can write single items as non-array values.</param>
    public SingleOrArrayConverter(bool canWrite) => CanWrite = canWrite;

    /// <summary>
    /// Gets whether the converter can write single items as non-array values.
    /// </summary>
    public bool CanWrite { get; }

    /// <summary>
    /// Reads and converts JSON to the target collection type.
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">Type to convert.</param>
    /// <param name="options">Serializer options.</param>
    /// <returns>The deserialized collection.</returns>
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

    /// <summary>
    /// Writes the collection to JSON, optionally as a single item if it contains only one element.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">The collection to write.</param>
    /// <param name="options">Serializer options.</param>
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