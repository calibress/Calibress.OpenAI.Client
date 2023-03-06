using System.Collections.Generic;
using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects;

/// <summary>
///     Represents the result of a Chat Completion API call.
/// </summary>
public class ChatApiResponse : ApiResponse, IChatApiResponse
{
    /// <inheritdoc />
    public List<ChatChoice> Choices { get; set; } = new();
}