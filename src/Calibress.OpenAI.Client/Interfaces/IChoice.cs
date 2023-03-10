using System.Collections.Generic;
using Calibress.OpenAI.Client.Objects;

namespace Calibress.OpenAI.Client.Interfaces;

/// <summary>
/// Represents a single choice generated by the API.
/// </summary>
public interface IChoice
{
    /// <summary>
    /// The index of this choice, indicating its position among all generated choices.
    /// </summary>
    int Index { get; set; }

    /// <summary>
    /// The log probabilities for each token in the generated text, if requested.
    /// </summary>
    List<double>? Logprobs { get; set; }

    /// <summary>
    /// The reason why the generation was stopped, if applicable.
    /// </summary>
    string? Finish_Reason { get; set; }
}

/// <summary>
/// Represents a single text choice generated by the API.
/// </summary>
public interface ITextChoice : IChoice
{
    /// <summary>
    /// The generated text for this choice.
    /// </summary>
    string? Text { get; set; }
}

/// <summary>
/// Represents a single choice for a chat completion response.
/// </summary>
public interface IChatChoice : IChoice
{
    /// <summary>
    /// The message content for the chat completion choice.
    /// </summary>
    Message? Message { get; set; }
}


/// <summary>
/// Represents a message in a chat conversation.
/// </summary>
public interface IMessage
{
    /// <summary>
    /// Gets or sets the role of the message (e.g. "system", "user", "assistant").
    /// </summary>
    string? Role { get; set; }

    /// <summary>
    /// Gets or sets the content of the message.
    /// </summary>
    string? Content { get; set; }
}