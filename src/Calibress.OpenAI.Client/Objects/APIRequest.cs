using System;
using System.Collections.Generic;
using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects;

/// <summary>
/// Represents a request to the OpenAI API.
/// </summary>
public class ApiRequest : IApiRequest
{
    /// <summary>
    /// The ID of the API request.
    /// </summary>
    public string Id { get; set; }


    /// <summary>
    /// The context ID of the API request.
    /// </summary>
    public string? ContextId { get; set; }

    /// <summary>
    /// The completion model used for the API request.
    /// </summary>
    public string? CompletionModel { get; set; }

    /// <summary>
    /// The ID of the user making the API request.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// The maximum number of tokens generated for the API request.
    /// </summary>
    public int MaxTokens { get; set; }

    /// <summary>
    /// The temperature for the API request.
    /// </summary>
    public double Temperature { get; set; }

    /// <summary>
    /// The top-p value for the API request.
    /// </summary>
    public double TopP { get; set; }

    /// <summary>
    /// The n value for the API request.
    /// </summary>
    public int N { get; set; }

    /// <summary>
    /// The stream flag for the API request.
    /// </summary>
    public bool Stream { get; set; }

    /// <summary>
    /// The logprobs flag for the API request.
    /// </summary>
    public int? Logprobs { get; set; }

    /// <summary>
    /// The echo flag for the API request.
    /// </summary>
    public bool Echo { get; set; }

    /// <summary>
    /// The stop object for the API request.
    /// </summary>
    public object? Stop { get; set; }

    /// <summary>
    /// The presence penalty for the API request.
    /// </summary>
    public double PresencePenalty { get; set; }

    /// <summary>
    /// The frequency penalty for the API request.
    /// </summary>
    public double FrequencyPenalty { get; set; }

    /// <summary>
    /// The best-of value for the API request.
    /// </summary>
    public int BestOf { get; set; }

    /// <summary>
    /// The logit bias dictionary for the API request.
    /// </summary>
    public Dictionary<int, double>? LogitBias { get; set; }


    /// <summary>
    /// Initializes a new instance of the ApiRequest class with the specified parameters.
    /// </summary>
    /// <param name="userId">The user ID for the API request.</param>
    /// <param name="maxTokens">The maximum number of tokens for the API request. Default value is 128.</param>
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
    /// <param name="completionModel">The completion model for the API request. Default value is null.</param>
    public ApiRequest(
        string userId,
        int maxTokens = 128,
        double temperature = 0.5,
        double topP = 0.8,
        int n = 1,
        bool stream = false,
        int? logprobs = null,
        bool echo = false,
        object? stop = null,
        double presencePenalty = 0.0,
        double frequencyPenalty = 0.0,
        int bestOf = 1,
        Dictionary<int, double>? logitBias = null!,
        string? contextId = null,
        string? completionModel = null)
    {
        Id = Guid.NewGuid().ToString();
        ContextId = contextId;
        CompletionModel = completionModel;
        UserId = userId;
        MaxTokens = maxTokens;
        Temperature = temperature;
        TopP = topP;
        N = n;
        Stream = stream;
        Logprobs = logprobs;
        Echo = echo;
        Stop = stop ?? null;
        PresencePenalty = presencePenalty;
        FrequencyPenalty = frequencyPenalty;
        BestOf = bestOf;
        LogitBias = logitBias ?? new Dictionary<int, double>();
    }

    /// <summary>
    /// Initializes a new instance of the ApiRequest class with the specified parameters.
    /// </summary>
    /// <param name="userId">The user ID for the API request.</param>
    /// <param name="maxTokens">The maximum number of tokens for the API request. Default value is 128.</param>
    /// <param name="temperature">The temperature for the API request. Default value is 0.5.</param>
    /// <param name="topP">The top P value for the API request. Default value is 0.8.</param>
    /// <param name="n">The n value for the API request. Default value is 1.</param>
    /// <param name="stream">The stream value for the API request. Default value is false.</param>
    /// <param name="stop">The stop value for the API request. Default value is null.</param>
    /// <param name="presencePenalty">The presence penalty for the API request. Default value is 0.0.</param>
    /// <param name="frequencyPenalty">The frequency penalty for the API request. Default value is 0.0.</param>
    /// <param name="logitBias">The logit bias dictionary for the API request. Default value is null.</param>
    /// <param name="contextId">The context ID for the API request. Default value is null.</param>
    /// <param name="completionModel">The completion model for the API request. Default value is null.</param>
    public ApiRequest(
        string userId,
        int maxTokens = 128,
        double temperature = 0.5,
        double topP = 0.8,
        int n = 1,
        bool stream = false,
        object? stop = null,
        double presencePenalty = 0.0,
        double frequencyPenalty = 0.0,
        Dictionary<int, double>? logitBias = null!,
        string? contextId = null,
        string? completionModel = null)
    {
        Id = Guid.NewGuid().ToString();
        ContextId = contextId;
        CompletionModel = completionModel;
        UserId = userId;
        MaxTokens = maxTokens;
        Temperature = temperature;
        TopP = topP;
        N = n;
        Stream = stream;
        Stop = stop ?? null;
        PresencePenalty = presencePenalty;
        FrequencyPenalty = frequencyPenalty;
        LogitBias = logitBias ?? new Dictionary<int, double>();
    }
}