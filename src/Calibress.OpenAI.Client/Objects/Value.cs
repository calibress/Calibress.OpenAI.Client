using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects
{
    /// <summary>
    /// Represents the result value returned by the OpenAI APIs.
    /// </summary>
    public class Value : IValue
    {
        /// <summary>
        /// Gets or sets the ID of the request.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the context ID of the request.
        /// </summary>
        public string? ContextId { get; set; }

        /// <summary>
        /// Gets or sets the result of the request.
        /// </summary>
        public string? Result { get; set; }
    }
}