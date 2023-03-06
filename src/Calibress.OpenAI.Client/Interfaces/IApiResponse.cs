using System.Net;
using Calibress.OpenAI.Client.Objects;

namespace Calibress.OpenAI.Client.Interfaces;

/// <summary>
/// Represents the base result of an API call.
/// </summary>
public interface IApiResponse
{
    /// <summary>
    /// The string Id of the API response.
    /// </summary>
    string? Id { get; set; }

    /// <summary>
    /// The object type of the API response.
    /// </summary>
    string? Object { get; set; }

    /// <summary>
    /// The timestamp of the API response in Unix epoch time format.
    /// </summary>
    long Created { get; set; }

    /// <summary>
    /// The name or ID of the model used for the API request.
    /// </summary>
    string? Model { get; set; }

    /// <summary>
    /// The usage statistics for the API request, including the number of tokens used for the prompt and the completion.
    /// </summary>
    Usage? Usage { get; set; }

    /// <summary>
    /// The value returned by the API call.
    /// </summary>
    IValue? Value { get; set; }

    /// <summary>
    /// The HTTP status code returned by the API call.
    /// </summary>
    HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// The content type of the response.
    /// </summary>
    object? ContentType { get; set; }

    /// <summary>
    /// The ID of the context used for the API call.
    /// </summary>
    string? ContextId { get; set; }

    /// <summary>
    /// The error object returned by the API request, or null if no error occurred.
    /// </summary>
    IApiError? ApiError { get; set; }

    /// <summary>
    /// Indicates whether the API request was successful and proper data was returned with no errors.
    /// </summary>
    public bool Success { get; set; }
}