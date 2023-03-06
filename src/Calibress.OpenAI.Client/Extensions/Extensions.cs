using System;
using Calibress.OpenAI.Client.Http;
using Calibress.OpenAI.Client.Interfaces;
using Calibress.OpenAI.Client.Objects;
using Microsoft.Extensions.DependencyInjection;

namespace Calibress.OpenAI.Client.Extensions
{
    public static class ApiClientExtensions
    {
        /// <summary>
        /// Adds the Text Completion Open API client to the service collection.
        /// </summary>
        /// <param name="services">The service collection to add the client to.</param>
        /// <param name="configure">A delegate to configure the API with.</param>
        public static void AddTextApiCompletionClient(this IServiceCollection services, Action<TextApiConfig> configure)
        {
            // Register the configuration object
            services.AddSingleton<ITextApiConfig>(provider =>
            {
                var config = new TextApiConfig();
                configure(config);
                return config;
            });

            // Register the API client
            services.AddSingleton<ITextCompletionApiHttpClient, TextCompletionApiHttpClient>();
        }


        /// <summary>
        /// Adds the Chat Completion Open API client to the service collection.
        /// </summary>
        /// <param name="services">The service collection to add the client to.</param>
        /// <param name="configure">A delegate to configure the API with.</param>
        public static void AddChatApiCompletionClient(this IServiceCollection services, Action<ChatApiConfig> configure)
        {
            // Register the configuration object
            services.AddSingleton<IChatApiConfig>(provider =>
            {
                var config = new ChatApiConfig();
                configure(config);
                return config;
            });

            // Register the API client
            services.AddSingleton<IChatCompletionApiHttpClient, ChatCompletionApiHttpClient>();
        }
    }
}
