using System.Collections.Generic;
using Calibress.OpenAI.Client.Objects;

namespace Calibress.OpenAI.Client.Interfaces;

/// <summary>
/// Represents the result of a Chat Completion API call.
/// </summary>
public interface IChatApiResponse : IApiResponse
{
    /// <summary>
    /// The list of choices returned by the API request.
    /// </summary>
    public List<ChatChoice> Choices { get; set; }
}