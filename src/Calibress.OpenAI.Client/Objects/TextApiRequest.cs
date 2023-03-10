using System.Collections.Generic;
using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects;

/// <summary>
/// Represents a request for text completion from an AI language model. Inherits from the base class ApiRequest and the interface ITextApiRequest.
/// </summary>
public class TextApiRequest : ApiRequest, ITextApiRequest
{
    /// <summary>
    /// Gets or sets the prompt used for the API request.
    /// </summary>
    public object Prompt { get; set; }

    /// <summary>
    /// Initializes a new instance of the TextApiRequest class with the specified parameters.
    /// </summary>
    /// <param name="prompt">The prompt for the API request.</param>
    /// <param name="userId">The user ID for the API request.</param>
    /// <param name="maxTokens">The maximum number of tokens for the API request. Default value is 512.</param>
    /// <param name="temperature">The temperature for the API request. Default value is 0.5.</param>
    /// <param name="topP">The top P value for the API request. Default value is 0.8.</param>
    /// <param name="n">The n value for the API request. Default value is 1.</param>
    /// <param name="stream">The stream value for the API request. Default value is false.</param>
    /// <param name="logprobs">The logprobs value for the API request. Default value is null.</param>
    /// <param name="echo">The echo value for the API request. Default value is false.</param>
    /// <param name="stop">The stop value for the API request. Default value is null.</param>
    /// <param name="presencePenalty">The presence penalty for the API request. Default value is 0.0.</param>
    /// <param name="frequencyPenalty">The frequency penalty for the API request. Default value is 0.0.</param>
    /// <param name="bestOf">The best of value for the API request. Default value is 1.</param>
    /// <param name="logitBias">The logit bias dictionary for the API request. Default value is null.</param>
    /// <param name="contextId">The context ID for the API request. Default value is null.</param>
    /// <param name="completionModel">The completion model for the API request. Default value is null if no default configuration has been set.</param>
    public TextApiRequest(object prompt, string userId, int maxTokens = 512, double temperature = 0.5, double topP = 0.8, int n = 1, bool stream = false, int? logprobs = null, bool echo = false, object? stop = null, double presencePenalty = 0, double frequencyPenalty = 0, int bestOf = 1, Dictionary<int, double>? logitBias = null, string? contextId = null, string? completionModel = null) : base(userId, maxTokens, temperature, topP, n, stream, logprobs, echo, stop, presencePenalty, frequencyPenalty, bestOf, logitBias, contextId, completionModel)
    {
        Prompt = prompt;
    }
}