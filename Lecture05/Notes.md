# Notes

```csharp
using var connection = new SqliteConnection("Filename=:memory:");
connection.Open();
var builder = new DbContextOptionsBuilder<SuperheroContext>();
builder.UseSqlite(connection);
using var context = new SuperheroContext(builder.Options);
context.Database.EnsureCreated();
GenerateTestData(context);
```

## Superheroes

```yaml
- name: Diana
  alterEgo: Wonder Woman
  occupation: Amazon Princess
  gender: Female
  firstAppearance: 1941
  city: Themyscira
  powers:
  - super strength
  - invulnerability
  - flight
  - combat skill
  - combat strategy
  - superhuman agility
  - healing factor
  - magic weaponry
- name: Selina Kyle
  alterEgo: Catwoman
  occupation: Thief
  gender: Female
  firstAppearance: 1940
  city: Gotham City
  powers:
  - exceptional martial artist
  - gymnastic ability
  - combat skill
```
