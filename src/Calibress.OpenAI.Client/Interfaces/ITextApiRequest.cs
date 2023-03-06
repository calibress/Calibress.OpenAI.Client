namespace Calibress.OpenAI.Client.Interfaces;

// <summary>
/// Represents a request to the OpenAI API for text completion.
/// </summary>
public interface ITextApiRequest : IApiRequest
{
    /// <summary>
    /// The prompt for the API request.
    /// </summary>
    object Prompt { get; set; }
}