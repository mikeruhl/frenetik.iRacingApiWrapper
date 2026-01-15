using Frenetik.iRacingApiWrapper;
using Frenetik.iRacingApiWrapper.Service;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register token context for per-request tokens
services.AddSingleton<ITokenContext, TokenContext>();

// Register HTTP client with authentication handler
services.AddHttpClient(IRacingApiService.HttpClientName)
    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
    .AddHttpMessageHandler<BearerTokenDelegatingHandler>();

// Register services
services.AddTransient<BearerTokenDelegatingHandler>();

// Use NoOpTokenProvider since tokens come from context
services.AddSingleton<ITokenProvider, NoOpTokenProvider>();

services.AddSingleton<IRacingApiService>();
services.AddLogging();

var userBearerToken = "YOUR_TOKEN_HERE"; // Obtain token from https://oauth.iracing.com/oauth2/book/authorization_code_flow.html and set here.

if (string.IsNullOrWhiteSpace(userBearerToken) || userBearerToken == "YOUR_TOKEN_HERE")
{
    throw new InvalidOperationException("No bearer token configured. Obtain a token from https://oauth.iracing.com/oauth2/book/authorization_code_flow.html and assign it to 'userBearerToken'.");
}

var provider = services.BuildServiceProvider();

var tokenContext = provider.GetRequiredService<ITokenContext>();
var iRacingApiService = provider.GetRequiredService<IRacingApiService>();
using (tokenContext.SetToken(userBearerToken))
{
    var memberInfo = await iRacingApiService.GetMemberInfo();

    Console.WriteLine($"The user has been a member since {memberInfo.MemberSince.ToShortDateString()}.");
}
