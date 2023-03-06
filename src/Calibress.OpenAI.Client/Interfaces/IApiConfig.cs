namespace Calibress.OpenAI.Client.Interfaces;

/// <summary>
/// Interface for the API configuration object
/// </summary>
public interface IApiConfig
{
    /// <summary>
    /// The API key to use for authentication
    /// </summary>
    string? ApiKey { get; set; }

    /// <summary>
    /// The endpoint URL for the API requests
    /// </summary>
    string? Endpoint { get; set; }

    /// <summary>
    /// The default Completion Model for the API requests
    /// </summary>
    string? CompletionModel { get; set; }
}