namespace Calibress.OpenAI.Client.Interfaces
{
    /// <summary>
    /// Represents a chat message in a chat completion request.
    /// </summary>
    public interface IChatCompletionMessage
    {
        /// <summary>
        /// The role of the chat message sender.
        /// </summary>
        string? Role { get; set; }

        /// <summary>
        /// The content of the chat message.
        /// </summary>
        string? Content { get; set; }
    }
}
