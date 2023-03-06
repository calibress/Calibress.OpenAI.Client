# Calibress Open AI Client

The Calibress Open AI Client is a .NET library that provides an easy-to-use interface for accessing the Open AI Text and Chat Completion APIs.

## Installation

To install the Calibress Open AI Client, simply add the Calibress.OpenAI.Client NuGet package to your project:

```C#
dotnet add package Calibress.OpenAI.Client
```

## Usage

To use the Calibress Open AI Client, you will need to obtain an API key from Open AI. Once you have an API key, you can use the AddChatApiCompletionClient or AddTextApiCompletionClient extension methods to register the client with your dependency injection container.

Here is an example of how to use the client to generate a text completion:

```C#
// Import necessary libraries
using Calibress.OpenAI.Client.Extensions;
using Calibress.OpenAI.Client.Http;
using Calibress.OpenAI.Client.Interfaces;
using Calibress.OpenAI.Client.Objects;
using Microsoft.Extensions.DependencyInjection;

// Set OpenAI API key 
const string apiKey = "<Your-OpenAI-API-Key-Here>";

// Initialize the service provider using dependency injection
var builder = new HostBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHttpClient();
        services.AddTextApiCompletionClient(c =>
        {
            c.ApiKey = apiKey;
            c.Endpoint = "https://api.openai.com/v1/completions";
            c.CompletionModel = "text-davinci-003";
        });
    });
var serviceProvider = builder.Build().Services;

// Get the text completion API from the service provider
var textCompletionApi = serviceProvider.GetService<ITextCompletionApiHttpClient>();

if (textCompletionApi != null)
{
    // Create a new text completion request object
    var request = textCompletionApi.CreateRequest(
        prompt: "Hello, my name is John and I",
        maxTokens: 50,
        temperature: 0.7
    );

    // Send the text completion request and wait for the response
    var response = await textCompletionApi.SendTextCompletionRequestAsync(request);

    if (response.Success)
    {
        // Print the generated text
        Console.WriteLine(response.Value?.Result);
    }
    else
    {
        // Print the error message
        Console.WriteLine(response.ApiError?.Error?.Message);
    }
}
else
{
    // If the text completion API is not found in the service provider,
    // display an error message to the user
    Console.WriteLine("Text completion API not found in service provider.");
}

```
Here is an example of how to use the client to generate a chat completion:

```C#
// Import necessary libraries
using Calibress.OpenAI.Client.Extensions;
using Calibress.OpenAI.Client.Http;
using Calibress.OpenAI.Client.Interfaces;
using Calibress.OpenAI.Client.Objects;
using Microsoft.Extensions.DependencyInjection;

// Set OpenAI API key 
const string apiKey = "<Your-OpenAI-API-Key-Here>";

// Initialize the service provider using dependency injection
var builder = new HostBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHttpClient();
        services.AddChatApiCompletionClient(c =>
        {
            c.ApiKey = apiKey;
            c.Endpoint = "https://api.openai.com/v1/chat/completions";
            c.CompletionModel = "gpt-3.5-turbo";
        });
    });
var serviceProvider = builder.Build().Services;

// Get the chat completion API from the service provider
var chatCompletionApi = serviceProvider.GetService<IChatCompletionApiHttpClient>();

if (chatCompletionApi != null)
{
   var request = chatCompletionApi.CreateRequest(
    new List<IChatCompletionMessage>
    {
         new ChatCompletionMessage { Role = Roles.System, Content = "This is a demonstration of the Calibress Open AI Client recipe feature. You are a helpful recipe and nutrition assistant." },
         new ChatCompletionMessage { Role = Roles.User, Content = "Can you give me a recipe for chicken parmesan? Remain on topic." },
         new ChatCompletionMessage { Role = Roles.Assistant, Content = "Here is a recipe I found: 1) Preheat oven to 375 degrees F (190 degrees C). 2) Heat oil in a large skillet over medium heat. Add chicken and saute for 4 to 5 minutes each side, or until browned. Remove chicken from skillet and place in a 9x13 inch baking dish. 3) Add garlic to the skillet and saute for 2 minutes. Then add tomato sauce, tomato paste, salt, oregano, and basil to the skillet and bring to a boil. Reduce heat and let simmer for 15 minutes. 4) Pour sauce over chicken and sprinkle with mozzarella cheese and Parmesan cheese. Bake in the preheated oven for 25 minutes or until cheese is bubbly." 
    },
    userId: "User1234",
    maxTokens: 512,
    temperature: 0.8
    );
}



    // Send the chat completion request and wait for the response
    var response = await chatCompletionApi.SendChatCompletionRequestAsync(request);

    if (response.Success)
    {
        // Print the generated chat response
        foreach (var choice in response.Choices)
        {
            Console.WriteLine($"Role: {choice.Role}, Text: {choice.Text}");
        }
    }
    else
    {
        // Print the error message
        Console.WriteLine(response.ApiError?.Error?.Message);
    }
}
else
{
    // If the chat completion API is not found in the service provider,
    // display an error message to the user
    Console.WriteLine("Chat completion API not found in service provider.");
}

```

## Sample Application

Note that a basic sample console app is included with the Calibress Open AI Client library, which demonstrates how to use the client to create a chatbot using the Chat Completion API. You can find the code for this sample in the samples folder of the library source code. The sample console app allows you to load a set of predefined prompts and responses from a JSON file, and use them to chat with the Open AI API. The console app also demonstrates how to use dependency injection to register the client, how to send chat completion requests, and how to handle API responses.


## MIT License

MIT License

Copyright (c) 2023 Craig Prescott - Calibress

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.


