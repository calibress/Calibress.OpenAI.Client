using System.Collections.Generic;
using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects;

/// <summary>
///     Represents the result of a Text Completion API call.
/// </summary>
public class TextApiResponse : ApiResponse, ITextApiResponse
{
    /// <inheritdoc />
    public List<TextChoice> Choices { get; set; } = new();
}