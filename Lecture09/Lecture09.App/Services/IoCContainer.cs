using Lecture09.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace Lecture09.App.Services
{
    public class IoCContainer
    {
        private static readonly Lazy<IServiceProvider> _lazyProvider = new Lazy<IServiceProvider>(() => ConjureServices());

        public static IServiceProvider Container { get => _lazyProvider.Value; }

        private static IServiceProvider ConjureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            // Register services here
            var client = new HttpClient { BaseAddress = new Uri("https://localhost:44327") };
            serviceCollection.AddSingleton(client);
            serviceCollection.AddScoped<IRestClient, RestClient>();
            serviceCollection.AddTransient<SuperheroesViewModel>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
