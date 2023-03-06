using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects
{
    /// <summary>
    /// Represents a chat message object for chat completion requests.
    /// </summary>
    public class ChatCompletionMessage : IChatCompletionMessage
    {
        /// <inheritdoc/>
        public string? Role { get; set; }

        /// <inheritdoc/>
        public string? Content { get; set; }

    }
}
