using System.Collections.Generic;

namespace Calibress.OpenAI.Client.Interfaces;

/// <summary>
/// Represents a request to the OpenAI API.
/// </summary>
public interface IApiRequest
{
    /// <summary>
    /// The unique ID of the API request.
    /// </summary>
    string Id { get; set; }

    /// <summary>
    /// The context ID of the API request.
    /// </summary>
    string? ContextId { get; set; }

    /// <summary>
    /// The completion model of the API request.
    /// </summary>
    string? CompletionModel { get; set; }

    /// <summary>
    /// The user ID of the API request.
    /// </summary>
    string UserId { get; set; }

    /// <summary>
    /// The maximum number of tokens to generate for the API request.
    /// </summary>
    int MaxTokens { get; set; }

    /// <summary>
    /// The temperature of the API request.
    /// </summary>
    double Temperature { get; set; }

    /// <summary>
    /// The nucleus sampling probability of the API request.
    /// </summary>
    double TopP { get; set; }

    /// <summary>
    /// The number of completions to generate for the API request.
    /// </summary>
    int N { get; set; }

    /// <summary>
    /// Whether to stream the API request or not.
    /// </summary>
    bool Stream { get; set; }

    /// <summary>
    /// Whether to include the log probabilities in the API response or not.
    /// </summary>
    int? Logprobs { get; set; }

    /// <summary>
    /// Whether to echo back the prompt in the API response or not.
    /// </summary>
    bool Echo { get; set; }

    /// <summary>
    /// A token at which to stop generation for the API request.
    /// </summary>
    object? Stop { get; set; }

    /// <summary>
    /// The presence penalty of the API request.
    /// </summary>
    double PresencePenalty { get; set; }

    /// <summary>
    /// The frequency penalty of the API request.
    /// </summary>
    double FrequencyPenalty { get; set; }

    /// <summary>
    /// The number of n-best completions to generate for the API request.
    /// </summary>
    int BestOf { get; set; }

    /// <summary>
    /// A dictionary of logit biases for the API request.
    /// </summary>
    Dictionary<int, double>? LogitBias { get; set; }
}