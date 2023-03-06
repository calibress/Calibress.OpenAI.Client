using Calibress.OpenAI.Client.Objects;

namespace Calibress.OpenAI.Client.Turbo.Console.Objects
{
    /// <summary>
    /// Represents a spark, which includes a title, description, and a collection of chat completion messages that are used to provide conversation prompts.
    /// </summary>
    public class Spark
    {
        /// <summary>
        /// Gets or sets the ID of the spark.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the spark.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the spark.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the collection of chat completion messages that are used to provide conversation prompts.
        /// </summary>
        public IEnumerable<ChatCompletionMessage>? ChatCompletionMessages { get; set; }

    }
}
