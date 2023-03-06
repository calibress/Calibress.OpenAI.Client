using System.Collections.Generic;
using System.Threading.Tasks;
using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Http;

// <summary>
// The IChatCompletionApiHttpClient interface that makes HTTP requests to the OpenAI Chat Completion API.
// </summary>
public interface IChatCompletionApiHttpClient
{
    // <summary>
    // Represents the API configuration object used for making HTTP requests to the OpenAI Completion API.
    // </summary>
    IApiConfig ApiConfig { get; }

    /// <summary>
    ///     Sends a chat completion request to the OpenAI API using the provided request object.
    /// </summary>
    /// <param name="request">The API request to send.</param>
    /// <returns>The API response from the OpenAI API.</returns>
    Task<IChatApiResponse?> SendChatCompletionRequestAsync(IChatApiRequest request);

    /// <summary>
    /// Initializes a new instance of the ChatApiRequest class with the specified collection of chat messages and optional parameters.
    /// </summary>
    /// <param name="completionChatMessages">The collection of chat messages for the API request.</param>
    /// <param name="userId">The user ID for the API request.</param>
    /// <param name="maxTokens">The maximum number of tokens for the API request. Default value is 512.</param>
    /// <param name="temperature">The temperature for the API request. Default value is 0.5.</param>
    /// <param name="topP">The top P value for the API request. Default value is 0.8.</param>
    /// <param name="n">The n value for the API request. Default value is 1.</param>
    /// <param name="stream">The stream value for the API request. Default value is false.</param>
    /// <param name="stop">The stop value for the API request. Default value is null.</param>
    /// <param name="presencePenalty">The presence penalty for the API request. Default value is 0.0.</param>
    /// <param name="frequencyPenalty">The frequency penalty for the API request. Default value is 0.0.</param>
    /// <param name="logitBias">The logit bias dictionary for the API request. Default value is null.</param>
    /// <param name="contextId">The context ID for the API request. Default value is null.</param>
    /// <param name="completionModel">The completion model for the API request. Default value is null if no default configuration has been set.</param>
    /// <returns>A Chat Completion API request object.</returns>
    IChatApiRequest CreateRequest(IEnumerable<IChatCompletionMessage> completionChatMessages, string userId,
        int maxTokens = 512,
        double temperature = 0.5, double topP = 1, int n = 1, bool stream = false, object? stop = null, double presencePenalty = 0, double frequencyPenalty = 0,
        Dictionary<int, double>? logitBias = null, string? contextId = null, string? completionModel = null);
}
