using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects;

public class Error : IError
{
    /// <inheritdoc />
    public string? Message { get; set; }

    /// <inheritdoc />
    public string? Type { get; set; }

    /// <inheritdoc />

    public string? Param { get; set; }

    /// <inheritdoc />

    public string? Code { get; set; }
}