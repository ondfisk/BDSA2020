# Notes

```csharp
var container = IoCContainer.Container;

var repo = container.GetService<ICharacterRepository>();

foreach (var character in await repo.ReadAsync())
{
    Console.WriteLine(character);
}

var service = container.GetService<IAnimalService>();

service.Speak();

var game = container.GetService<Game>();
game.Run();

var config = container.GetService<IConfig>();

System.Console.WriteLine(config.ClientId);

var article = new Article
{
    Author = "Woodward and Bernstein",
    Body = "Lots of stuff about a crook",
    Title = "Deep Throat"
};

var facade = container.GetRequiredService<Facade>();
facade.Publish(article);

StrategyContainer.Run();

var repo = container.GetService<ICharacterRepository>();
var bridge = new Bridge(repo);

await bridge.PrintAll();

serviceCollection.AddTransient<IAnimal, Wolf>();
serviceCollection.AddTransient<IAnimalService, AnimalService>();

serviceCollection.AddSingleton<IConfig, HardcodedConfig>();

serviceCollection.AddScoped<IArchiver, Archiver>();
serviceCollection.AddScoped<IPublisher, Publisher>();
serviceCollection.AddScoped<INotifier, Notifier>();
serviceCollection.AddScoped<IPeopleRepository, PeopleRepository>();
serviceCollection.AddScoped<Facade>();

serviceCollection.AddTransient<HashAlgorithm>(_ => MD5.Create());
serviceCollection.AddTransient<HashAlgorithm>(_ => SHA1.Create());
serviceCollection.AddTransient<HashAlgorithm>(_ => SHA256.Create());
serviceCollection.AddTransient<HashAlgorithm>(_ => SHA512.Create());

serviceCollection.AddTransient<IWeapon, Crossbow>();
serviceCollection.AddTransient<IWeapon, Grenade>();
serviceCollection.AddTransient<IWeapon, Spear>();
serviceCollection.AddTransient<IWeapon, Sword>();
serviceCollection.AddScoped<IWeaponFactory, WeaponFactoryContainer>();
serviceCollection.AddScoped<Game, Game>();

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddUserSecrets(typeof(Program).Assembly)
    .Build();

var connectionString = configuration.GetConnectionString("Futurama");

serviceCollection.AddDbContext<CharacterContext>(o => o.UseSqlServer(connectionString));
serviceCollection.AddScoped<ICharacterContext, CharacterContext>();
serviceCollection.AddScoped<ICharacterRepository>(s => new AdoNetCharacterRepository(connectionString));

var container = IoCContainer.Container;

var repo = container.GetService<ICharacterRepository>();

var bridge = new Bridge(repo);

await bridge.PrintAll();
```

```xml
<ItemGroup>
  <Content Include="appsettings.json">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </Content>
</ItemGroup>
```
