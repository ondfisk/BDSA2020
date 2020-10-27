using Lecture08.Models.Bridge;
using Lecture08.Models.Facade;
using Lecture08.Models.FactoryMethod;
using Lecture08.Models.IoCContainer;
using Lecture08.Models.Singleton;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Lecture08.App
{
    public class IoCContainer
    {
        private static readonly Lazy<IServiceProvider> _lazyProvider = new Lazy<IServiceProvider>(() => ConfigureServices());

        public static IServiceProvider Container { get => _lazyProvider.Value; }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            // Register services here

            return serviceCollection.BuildServiceProvider();
        }
    }
}
