using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects;

/// <summary>
/// Represents a text completion configuration object for the OpenAI API.
/// </summary>
public class TextApiConfig : ApiConfig, ITextApiConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextApiConfig"/> class.
    /// </summary>
    public TextApiConfig()
    {

    }
    /// <summary>
    /// Initializes a new instance of the <see cref="TextApiConfig"/> class with the specified API key and API endpoint.
    /// </summary>
    /// <param name="apiKey">The API key for the OpenAI API.</param>
    /// <param name="endpoint">The API endpoint for the OpenAI API.</param>
    public TextApiConfig(string apiKey, string endpoint) : base(apiKey,endpoint)
    {

    }
}