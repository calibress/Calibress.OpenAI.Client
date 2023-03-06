// See https://aka.ms/new-console-template for more information

// Import necessary libraries
using Calibress.OpenAI.Client.Extensions;
using Calibress.OpenAI.Client.Http;
using Calibress.OpenAI.Client.Interfaces;
using Calibress.OpenAI.Client.Objects;
using Calibress.OpenAI.Client.Statics;
using Calibress.OpenAI.Client.Turbo.Console.Objects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Globalization;

// Set OpenAI API key 
const string apiKey = "<Your-OpenAI-Key-Here>";

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
    // Print initial message
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Calibress Open AI Client Code Console Demonstration");

    // Load sparks from JSON file
    List<Spark>? sparks;
    using (StreamReader r = new StreamReader("sparks.json"))
    {
        var json = r.ReadToEnd();
        sparks = JsonConvert.DeserializeObject<List<Spark>>(json);
    }

    // Prompt the user to select a spark
    Console.WriteLine("Please select a spark:");

    for (int i = 0; i < sparks!.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {sparks[i].Title} - {sparks[i].Description}");
    }

    // Modify the chatMessages collection to prepend the current culture info to system messages
    foreach (var message in from spark in sparks! from message in spark.ChatCompletionMessages! where message.Role == "system" select message)
    {
        message.Content = $"({CultureInfo.CurrentUICulture.Name}) {message.Content}";
    }

    // Reset console color
    Console.ResetColor();

    // Read the user's input and validate it
    var selectedSparkIndex = -1;
    while (selectedSparkIndex < 0 || selectedSparkIndex >= sparks.Count)
    {
        Console.Write("Enter the number of the spark you want to select: ");
        var input = Console.ReadLine();
        if (int.TryParse(input, out selectedSparkIndex))
        {
            selectedSparkIndex--;
            Console.WriteLine($"Selected: {sparks[selectedSparkIndex].Title}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    // Initialize the chatMessages collection with the chat completion messages of the selected spark
    var chatMessages = new List<IChatCompletionMessage>();
    chatMessages.AddRange(sparks[selectedSparkIndex].ChatCompletionMessages ?? Array.Empty<ChatCompletionMessage>());

    // Set the maximum number of API tokens allowed in a conversation
    const int apiMaxTokens = 4096;

    var tokensUsed = 0;
    var userId = Guid.NewGuid().ToString();

    while (true)
    {
        // Print user prompt
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("User: ");
        Console.ResetColor();

        // Get user input
        Console.ForegroundColor = ConsoleColor.Gray;
        var userInput = Console.ReadLine();
        Console.ResetColor();

        // Print thinking message
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Thinking...");
        Console.ResetColor();

        // Add user input to chatMessages collection
        chatMessages.Add(new ChatCompletionMessage() { Role = Roles.User, Content = userInput });

        // Create chat completion request object
        var request = chatCompletionApi?.CreateRequest(chatMessages, userId);

        // Send chat completion request and wait for response
        if (request is not null)
        {
            IChatApiResponse? response = await (chatCompletionApi?.SendChatCompletionRequestAsync(request)!).ConfigureAwait(false);
            Console.Write(new string('\b', "Thinking...".Length));
            if (response != null)
            {
                if (response.Success)
                {
                    if (response.Usage != null)
                    {
                        // Update token count and add AI response to chat messages
                        tokensUsed += response.Usage.Total_Tokens;
                        chatMessages.Add(new ChatCompletionMessage() { Role = Roles.Assistant, Content = response.Value?.Result ?? string.Empty });

                        // Print AI response
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Assistant: ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(chatMessages.Last().Content);
                        Console.ResetColor();

                        // Print token usage information
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"User Prompt Tokens: {response.Usage.Prompt_Tokens}, AI Completion Tokens: {response.Usage.Completion_Tokens}, Turn Total Tokens: {response.Usage.Total_Tokens}, Conversation Total Tokens: {tokensUsed}");
                        Console.ResetColor();

                        // Check if maximum token limit has been exceeded
                        if (tokensUsed >= apiMaxTokens)
                        {
                            //print maximum token limit message
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Maximum tokens used.");
                            Console.ResetColor();

                            // Ask user if they want to continue conversation
                            Console.Write("Do you want to continue the conversation? (y/n) ");
                            var input = Console.ReadLine();
                            if (input != null && input.ToLower() == "y")
                            {
                                // Reset token count and continue conversation
                                tokensUsed = 0;

                                //Get the last message
                                var last = chatMessages.Last();

                                // Clear chat messages 
                                chatMessages.Clear();

                                //Add the selected spark's chat completion messages and the last message to maintain the conversation
                                chatMessages.AddRange(sparks[selectedSparkIndex].ChatCompletionMessages!);
                                chatMessages.Add(last);

                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                }
                else
                {
                    // Print error message if response is not successful
                    if (response.ApiError?.Error?.Message != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(response?.ApiError?.Error?.Message ?? "Oops");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                // Print message if response is null
                Console.WriteLine("API response was null.");
            }
        }
        else
        {
            // Print message if request is null
            Console.WriteLine("API request was null.");
        }
    }
}
else
{
    // If the chat completion API is not found in the service provider,
    // display an error message to the user
    Console.WriteLine("Chat completion API not found in service provider.");
}


