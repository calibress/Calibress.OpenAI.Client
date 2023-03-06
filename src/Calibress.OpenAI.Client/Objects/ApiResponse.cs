using System.Net;
using Calibress.OpenAI.Client.Interfaces;

namespace Calibress.OpenAI.Client.Objects;

/// <summary>
///     Represents the response from the API.
/// </summary>
public abstract class ApiResponse : IApiResponse
{
    public string? Id { get; set; }
    public string? Object { get; set; }
    public long Created { get; set; }
    public string? Model { get; set; }
    public Usage? Usage { get; set; }
    /// <summary>
    ///     Gets or sets the response value.
    /// </summary>
    public IValue? Value { get; set; }

    /// <summary>
    ///     Gets or sets the response status code.
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    ///     Gets or sets the response content type.
    /// </summary>
    public object? ContentType { get; set; }

    /// <summary>
    ///     Gets or sets the context ID of the response.
    /// </summary>
    public string? ContextId { get; set; }


    /// <summary>
    ///     The error object returned by the API request, or null if no error occurred.
    /// </summary>
    public IApiError? ApiError { get; set; }

    /// <summary>
    ///     Indicates whether the API request was successful and proper data was returned with no errors.
    /// </summary>
    public bool Success { get; set; }

}

/// <summary>
/// Represents the usage statistics for an OpenAI API request.
/// </summary>
public class Usage
{

    /// <summary>
    /// The number of tokens used in the API request prompt.
    /// </summary>
    public int Prompt_Tokens { get; set; }
    
    /// <summary>
    /// The number of tokens used in the API request completion.
    /// </summary>
    public int Completion_Tokens { get; set; }

    /// <summary>
    /// The total number of tokens used in the API request.
    /// </summary>
    public int Total_Tokens { get; set; }

}