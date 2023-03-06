namespace Calibress.OpenAI.Client.Interfaces;

/// <summary>
/// Represents the result value returned by the OpenAI APIs.
/// </summary>
public interface IValue
{
    /// <summary>
    /// Gets or sets the ID of the request.
    /// </summary>
    string? Id { get; set; }

    /// <summary>
    /// Gets or sets the context ID of the request.
    /// </summary>
    string? ContextId { get; set; }

    /// <summary>
    /// Gets or sets the result of the request.
    /// </summary>
    string? Result { get; set; }
}
