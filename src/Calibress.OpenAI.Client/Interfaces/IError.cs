namespace Calibress.OpenAI.Client.Interfaces;

/// <summary>
/// Represents a generic error returned by the OpenAI API, including a message, type, parameter, and code.
/// </summary>
public interface IError
{
    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    string? Message { get; set; }

    /// <summary>
    /// Gets or sets the type of the error.
    /// </summary>
    string? Type { get; set; }

    /// <summary>
    /// Gets or sets the parameter that caused the error, if applicable.
    /// </summary>
    string? Param { get; set; }

    /// <summary>
    /// Gets or sets the error code, if applicable.
    /// </summary>
    string? Code { get; set; }
}