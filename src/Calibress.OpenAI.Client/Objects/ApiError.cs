using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects;

/// <summary>
/// Represents an implementation of the <see cref="IApiError"/> interface.
/// </summary>
public class ApiError : IApiError
{
    public Error? Error { get; set; }
}