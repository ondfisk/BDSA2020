# Notes

```csharp
public interface ISuperheroRepository
{
    Task<(Response response, int superheroId)> CreateAsync(SuperheroCreateDTO superhero);
    Task<SuperheroDetailsDTO> ReadAsync(int superheroId);
    IQueryable<SuperheroListDTO> Read();
    Task<Response> UpdateAsync(SuperheroUpdateDTO superhero);
    Task<Response> DeleteAsync(int superheroId);
}

Parallel.For(0, 999, i => {
    Console.WriteLine(i);
});

Parallel.ForEach(numbers, i => {
    Console.WriteLine(i);
});

Parallel.Invoke(SuperLongRunningThingy1, 
    SuperLongRunningThingy2, 
    SuperLongRunningThingy3, 
    SuperLongRunningThingy4);
```
