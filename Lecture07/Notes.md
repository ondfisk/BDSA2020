# Notes

```powershell
dotnet dev-certs https --trust

dotnet new webapi -o Lecture07.Api --no-https

dotnet add package System.Text.Json
```

```csharp
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]

services.AddDbContext<SuperheroContext>(o => o.UseSqlite("Filename=superheroes.db"));
services.AddScoped<ISuperheroContext, SuperheroContext>();
services.AddScoped<ISuperheroRepository, SuperheroRepository>();
```

```http
GET http://localhost:5000/superheroes/1

###

POST http://localhost:5000/superheroes
content-type: application/json

{
    "name": "Clark Kent",
    "alterEgo": "Superman",
    "occupation": "Reporter",
    "gender": "Male",
    "firstAppearance": 1938,
    "cityName": "Metropolis",
    "powers": [
        "super strength",
        "flight",
        "invulnerability",
        "super speed",
        "heat vision",
        "freeze breath",
        "x-ray vision",
        "superhuman hearing",
        "healing factor"
    ]
}
```
