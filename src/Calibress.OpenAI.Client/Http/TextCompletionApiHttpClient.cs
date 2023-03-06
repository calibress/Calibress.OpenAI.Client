using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Calibress.OpenAI.Client.Interfaces;
using Calibress.OpenAI.Client.Objects;
using Newtonsoft.Json;

namespace Calibress.OpenAI.Client.Http;

// <summary>
// Implementation of the ITextCompletionApiHttpClient interface that makes HTTP requests to the OpenAI Text Completion API.
// </summary>
public class TextCompletionApiHttpClient : BaseHttpClient, ITextCompletionApiHttpClient
{
    /// <summary>
    /// Represents the API configuration object used for making HTTP requests to the OpenAI Completion API.
    /// </summary>
    public IApiConfig ApiConfig { get; }

    /// <summary>
    ///     Initializes a new instance of the TextCompletionApiHttpClient class with the specified API configuration and HTTP
    ///     client.
    /// </summary>
    /// <param name="apiConfig">The API configuration to use for requests.</param>
    /// <param name="client">The HTTP client to use for sending requests.</param>
    public TextCompletionApiHttpClient(ITextApiConfig apiConfig, HttpClient client) : base(client)
    {
        ApiConfig = apiConfig;
    }

    /// <summary>
    ///     Creates an API request object using the specified parameters.
    /// </summary>
    /// <param name="prompt">The prompt to use for the API request.</param>
    /// <param name="userId">The user ID to use for the API request.</param>
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
    /// <returns>A Text Completion API request object.</returns>
    public ITextApiRequest CreateRequest(string prompt, string userId, int maxTokens = 512,
        double temperature = 0.5, double topP = 0.8, int n = 1, bool stream = false, int? logprobs = null,
        bool echo = false,
        object? stop = null, double presencePenalty = 0, double frequencyPenalty = 0, int bestOf = 1,
        Dictionary<int, double>? logitBias = null, string? contextId = null, string? completionModel = null)
    {
        if (completionModel == null) completionModel = ApiConfig.CompletionModel;

        return new TextApiRequest(prompt, userId, maxTokens, temperature, topP, n, stream, logprobs, echo, stop,
            presencePenalty, frequencyPenalty, bestOf, logitBias, contextId, completionModel);
    }


    /// <summary>
    ///     Sends a text completion request to the OpenAI API using the provided request object.
    /// </summary>
    /// <param name="request">The API request to send.</param>
    /// <returns>The API response from the OpenAI API.</returns>
    public async Task<ITextApiResponse?> SendTextCompletionRequestAsync(ITextApiRequest request)
    {
        // Define the API endpoint based on the API configuration
        var endpoint = ApiConfig.Endpoint;

        // Define the request data to send to the API
        var requestData = new
        {
            prompt = request.Prompt,
            model = request.CompletionModel,
            max_tokens = request.MaxTokens,
            n = request.N,
            temperature = request.Temperature,
            frequency_penalty = request.FrequencyPenalty,
            presence_penalty = request.PresencePenalty,
            stop = request.Stop ?? null,
            logprobs = request.Logprobs ?? null,
            echo = request.Echo,
            stream = request.Stream,
            best_of = request.BestOf,
            logit_bias = request.LogitBias ?? null
        };

        // Serialize the request data to JSON
        var json = JsonConvert.SerializeObject(requestData);

        // Define the request content as JSON
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Create a new HttpRequestMessage object and set its content to the StringContent object
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = content
        };

        // Add the "Authorization" header to the HttpRequestMessage object
        httpRequestMessage.Headers.Add("Authorization", $"Bearer {ApiConfig.ApiKey}");

        // Send the API request and get the response
        var response = await Client.SendAsync(httpRequestMessage);

        // Read the response content as a string
        var responseString = await response.Content.ReadAsStringAsync();

        ITextApiResponse apiResponse;

        // If the API call was successful and the response string is not empty, deserialize the response and assign it to apiResponse
        if (response.IsSuccessStatusCode)
        {
            if (!string.IsNullOrEmpty(responseString))
            {
                // Deserialize the response string into ApiResponse. If it is null, create a new ApiResponse object with a new ApiError object with the reason phrase set as the error message.
                apiResponse = JsonConvert.DeserializeObject<TextApiResponse>(responseString) ?? new TextApiResponse
                    { ApiError = new ApiError { Error = new Error { Message = response.ReasonPhrase } } };
                apiResponse.StatusCode = response.StatusCode;
                apiResponse.ContextId = request.ContextId;
                apiResponse.Success = true;

                // If the response has only one choice, set the value result to the text of the first choice and count the number of tokens
                if (apiResponse.Choices.Count == 1)
                {
                    apiResponse.Value = new Value();
                    apiResponse.Value.Result = apiResponse.Choices[0].Text;
                }
            }
            // If the response string is empty, create a new ApiResponse object with a new ApiError object with the reason phrase set as the error message.
            else
            {
                apiResponse = new TextApiResponse
                {
                    StatusCode = response.StatusCode,
                    ContextId = request.ContextId,
                    Success = false,
                    ApiError = new ApiError { Error = new Error { Message = response.ReasonPhrase } }
                };
            }
        }
        // If the API call was not successful, create a new ApiResponse object with the deserialized ApiError object from the response string
        else
        {
            apiResponse = new TextApiResponse
            {
                StatusCode = response.StatusCode,
                ContextId = request.ContextId,
                Success = false,
                ApiError = JsonConvert.DeserializeObject<ApiError>(responseString)
            };
        }

        return apiResponse;
    }
}