using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects;

/// <summary>
/// Represents a chat completion configuration object for the OpenAI API.
/// </summary>
public class ChatApiConfig : ApiConfig, IChatApiConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChatApiConfig"/> class.
    /// </summary>
    public ChatApiConfig()
    {

    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ChatApiConfig"/> class with the specified API key and API endpoint.
    /// </summary>
    /// <param name="apiKey">The API key for the OpenAI API.</param>
    /// <param name="endpoint">The API endpoint for the OpenAI API.</param>
    public ChatApiConfig(string apiKey, string endpoint) : base(apiKey, endpoint)
    {

    }
}