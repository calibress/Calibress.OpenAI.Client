using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects;

/// <summary>
/// Represents a configuration object for the OpenAI API.
/// </summary>
public abstract class ApiConfig : IApiConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiConfig"/> class.
    /// </summary>
    protected ApiConfig()
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiConfig"/> class with the specified API key, application ID, and API endpoint.
    /// </summary>
    /// <param name="apiKey">The API key for the OpenAI API.</param>
    /// <param name="endpoint">The API endpoint for the OpenAI API.</param>
    protected ApiConfig(string apiKey, string endpoint)
    {
        ApiKey = apiKey;
        Endpoint = endpoint;
    }

    /// <inheritdoc/>
    public string? ApiKey { get; set; }

    /// <inheritdoc/>
    public string? Endpoint { get; set; }

    /// <inheritdoc/>
    public string? CompletionModel { get; set; }
}
