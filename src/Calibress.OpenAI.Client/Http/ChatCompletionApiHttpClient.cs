using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Calibress.OpenAI.Client.Interfaces;
using Calibress.OpenAI.Client.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Calibress.OpenAI.Client.Http;

// <summary>
// Implementation of the IChatCompletionApiHttpClient interface that makes HTTP requests to the OpenAI Chat Completion API.
// </summary>
public class ChatCompletionApiHttpClient : BaseHttpClient, IChatCompletionApiHttpClient
{
    /// <inheritdoc/>
    public IApiConfig ApiConfig { get; }


    /// <summary>
    ///     Initializes a new instance of the ChatCompletionApiHttpClient class with the specified API configuration and HTTP
    ///     client.
    /// </summary>
    /// <param name="apiConfig">The API configuration to use for requests.</param>
    /// <param name="client">The HTTP client to use for sending requests.</param>
    public ChatCompletionApiHttpClient(IChatApiConfig apiConfig, HttpClient client) : base(client)
    {
        ApiConfig = apiConfig;
    }

    /// <inheritdoc/>
    public IChatApiRequest CreateRequest(IEnumerable<IChatCompletionMessage> completionChatMessages, string userId,
        int maxTokens = 512,
        double temperature = 0.5, double topP = 1, int n = 1, bool stream = false, 
        object? stop = null, double presencePenalty = 0, double frequencyPenalty = 0,
        Dictionary<int, double>? logitBias = null, string? contextId = null, string? completionModel = null)
    {
        if (completionModel == null) completionModel = ApiConfig.CompletionModel;

        return new ChatApiRequest(completionChatMessages, userId, maxTokens, temperature, topP, n, stream, stop,
            presencePenalty, frequencyPenalty,logitBias, contextId, completionModel);
    }

    /// <inheritdoc/>
    public async Task<IChatApiResponse?> SendChatCompletionRequestAsync(IChatApiRequest request)
    {
        // Define the API endpoint based on the API configuration
        var endpoint = ApiConfig.Endpoint;

        // Convert the chat messages to a JSON array
        var jsonArray = new JArray();
        foreach (var message in request.CompletionChatMessages)
        {
            var jsonObject = new JObject(
                new JProperty("role", message.Role),
                new JProperty("content", message.Content)
            );
            jsonArray.Add(jsonObject);
        }


        // Define the request data to send to the API
        var requestData = new
        {
            model = request.CompletionModel,
            max_tokens = request.MaxTokens,
            n = request.N,
            temperature = request.Temperature,
            frequency_penalty = request.FrequencyPenalty,
            presence_penalty = request.PresencePenalty,
            stop = request.Stop ?? null,
            stream = request.Stream,
            logit_bias = request.LogitBias ?? null,
            messages = jsonArray
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

        IChatApiResponse apiResponse;

        // If the API call was successful and the response string is not empty, deserialize the response and assign it to apiResponse
        if (response.IsSuccessStatusCode)
        {
            if (!string.IsNullOrEmpty(responseString))
            {
                // Deserialize the response string into ApiResponse. If it is null, create a new ApiResponse object with a new ApiError object with the reason phrase set as the error message.
                apiResponse = JsonConvert.DeserializeObject<ChatApiResponse>(responseString) ?? new ChatApiResponse
                    { ApiError = new ApiError { Error = new Error { Message = response.ReasonPhrase } } };
                apiResponse.StatusCode = response.StatusCode;
                apiResponse.ContextId = request.ContextId;
                apiResponse.Success = true;

                // If the response has only one choice, set the value result to the text of the first choice and count the number of tokens
                if (apiResponse.Choices.Count == 1)
                {
                    apiResponse.Value = new Value();
                    var message = apiResponse.Choices[0].Message;
                    if (message != null)
                        apiResponse.Value.Result = message.Content;
                }
            }
            // If the response string is empty, create a new ApiResponse object with a new ApiError object with the reason phrase set as the error message.
            else
            {
                apiResponse = new ChatApiResponse
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
            apiResponse = new ChatApiResponse
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