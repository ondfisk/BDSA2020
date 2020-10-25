using Lecture08.Models.Bridge;
using Lecture08.Models.ChainOfResponsibility.Approval;
using Lecture08.Models.ChainOfResponsibility.ATM;
using Lecture08.Models.Facade;
using Lecture08.Models.FactoryMethod;
using Lecture08.Models.IoCContainer;
using Lecture08.Models.Iterator;
using Lecture08.Models.Singleton;
using Lecture08.Models.Strategy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Lecture08.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = IoCContainer.Container;

            // var service = container.GetService<IAnimalService>();

            // service.Speak();

            var game = container.GetService<Game>();
            game.Run();

            // var config = container.GetService<IConfig>();

            // System.Console.WriteLine(config.ClientId);

            // var article = new Article
            // {
            //     Author = "Woodward and Bernstein",
            //     Body = "Lots of stuff about a crook",
            //     Title = "Deep Throat"
            // };

            // var facade = container.GetRequiredService<Facade>();
            // facade.Publish(article);

            // StrategyContainer.Run();

            // var repo = container.GetService<ICharacterRepository>();
            // var bridge = new Bridge(repo);

            // await bridge.PrintAll();
        }
    }
}
