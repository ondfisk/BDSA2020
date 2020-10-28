using System;
using System.Linq;
using System.Threading.Tasks;
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

namespace Lecture08.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = IoCContainer.Container;

            // var service = container.GetService<IAnimalService>();

            // service.Speak();

            // var game = new Game();
            // game.Run();

            // var game = container.GetRequiredService<Game>();
            // game.Run();

            // var config = container.GetRequiredService<IConfig>(); //HardcodedConfig.Instance;

            // Console.WriteLine(config.ClientId);

            // Iterator.BigIntegerDemo();

            var article = new Article
            {
                Title = "The subject of stuff",
                Author = "me",
                Body = "... not important stuff ..."
            };

            // var f = container.GetRequiredService<Facade>();
            // f.Publish(article);

            // StrategyContainer.Run();

            container.GetServices<IWeapon>().Where(c => c.Name == "Spoon");

            var repo = container.GetService<ICharacterRepository>();

            foreach (var c in await repo.ReadAsync())
            {
                Console.WriteLine(c);
            }
        }
    }
}
