using Calibress.OpenAI.Client.Objects;

namespace Calibress.OpenAI.Client.Interfaces;

/// <summary>
/// Represents an error returned by the OpenAI API, containing details about the error.
/// </summary>
public interface IApiError
{
    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    Error? Error { get; set; }
}