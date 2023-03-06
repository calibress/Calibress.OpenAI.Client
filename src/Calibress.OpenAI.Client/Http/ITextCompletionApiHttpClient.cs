using System.Collections.Generic;
using System.Threading.Tasks;
using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Http;

/// <summary>
///     Interface for the completion API HTTP client.
/// </summary>
public interface ITextCompletionApiHttpClient
{
    IApiConfig ApiConfig { get; }

    /// <summary>
    ///     Sends a completion request to the API using the provided request object.
    /// </summary>
    /// <param name="request">The API request to send.</param>
    /// <returns>The API response from the API.</returns>
    Task<ITextApiResponse?> SendTextCompletionRequestAsync(ITextApiRequest request);

    /// <summary>
    ///     Creates a new API request object with the provided parameters.
    /// </summary>
    /// <param name="prompt">The prompt to generate a completion for.</param>
    /// <param name="userId">The ID of the user making the request.</param>
    /// <param name="maxTokens">The maximum number of tokens to generate.</param>
    /// <param name="temperature">The sampling temperature to use.</param>
    /// <param name="topP">The top-p sampling cutoff to use.</param>
    /// <param name="n">The number of completions to generate.</param>
    /// <param name="stream">Whether to generate the completions as a stream.</param>
    /// <param name="logprobs">The maximum number of log probabilities to generate.</param>
    /// <param name="echo">Whether to include the prompt in the completion.</param>
    /// <param name="stop">The stopping criteria to use.</param>
    /// <param name="presencePenalty">The presence penalty to use.</param>
    /// <param name="frequencyPenalty">The frequency penalty to use.</param>
    /// <param name="bestOf">The number of completions to generate and return the best of.</param>
    /// <param name="logitBias">The logit bias to use.</param>
    /// <param name="contextId">The ID of the context to use.</param>
    /// <param name="completionModel">The completion model to use.</param>
    /// <param name="applicationId">The ID of the application to use.</param>
    /// <returns>The created API request object.</returns>
    ITextApiRequest CreateRequest(string prompt, string userId, int maxTokens = 512,
        double temperature = 0.5, double topP = 1, int n = 1, bool stream = false, int? logprobs = null,
        bool echo = false, object? stop = null, double presencePenalty = 0, double frequencyPenalty = 0, int bestOf = 1,
        Dictionary<int, double>? logitBias = null, string? contextId = null, string? completionModel = null);
}