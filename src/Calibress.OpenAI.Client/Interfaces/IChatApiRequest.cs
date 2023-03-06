using System.Collections.Generic;

namespace Calibress.OpenAI.Client.Interfaces;

/// <summary>
/// Represents a request to the OpenAI API for chat completion.
/// </summary>
public interface IChatApiRequest : IApiRequest
{
    /// <summary>
    /// The collection of chat messages for the API request.
    /// </summary>
    IEnumerable<IChatCompletionMessage> CompletionChatMessages { get; set; }
}