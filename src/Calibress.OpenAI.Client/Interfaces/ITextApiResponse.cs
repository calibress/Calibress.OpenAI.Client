using System.Collections.Generic;
using Calibress.OpenAI.Client.Objects;

namespace Calibress.OpenAI.Client.Interfaces;

/// <summary>
/// Represents the result of a Text Completion API call.
/// </summary>
public interface ITextApiResponse : IApiResponse
{
    /// <summary>
    /// The list of choices returned by the API request.
    /// </summary>
    public List<TextChoice> Choices { get; set; }
}