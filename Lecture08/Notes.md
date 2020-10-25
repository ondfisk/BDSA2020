# Notes

```csharp
var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Futurama;Integrated Security=True";

serviceCollection.AddScoped<ICharacterRepository>(_ => new AdoNetCharacterRepository(connectionString));

IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

var connectionString = configuration.GetConnectionString("Futurama");

serviceCollection.AddDbContext<CharacterContext>(o => o.UseSqlServer(connectionString));
serviceCollection.AddScoped<ICharacterContext, CharacterContext>();
serviceCollection.AddScoped<ICharacterRepository, EntityFrameworkCharacterRepository>();

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

```json
{
    "ConnectionStrings": {
        "Futurama": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Futurama;Integrated Security=True"
    }
}
```