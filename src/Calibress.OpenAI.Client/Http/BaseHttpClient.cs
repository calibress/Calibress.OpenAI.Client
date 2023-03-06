using System.Net.Http;

namespace Calibress.OpenAI.Client.Http;


/// <summary>
/// Base class for HTTP clients, providing an instance of HttpClient.
/// </summary>
public abstract class BaseHttpClient
{
    /// <summary>
    /// Protected instance of HttpClient for sending HTTP requests.
    /// </summary>
    protected readonly HttpClient Client;

    /// <summary>
    /// Initializes a new instance of the BaseHttpClient class with the specified HTTP client.
    /// </summary>
    /// <param name="client">The HttpClient to use for sending HTTP requests.</param>
    protected BaseHttpClient(HttpClient client)
    {
        Client = client;
    }
}


