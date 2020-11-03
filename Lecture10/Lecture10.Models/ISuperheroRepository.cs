using Lecture10.Shared;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Lecture10.Models
{
    public interface ISuperheroRepository
    {
        Task<int> Create(SuperheroCreateDTO superhero);
        Task<SuperheroDetailsDTO> Read(int superheroId);
        IQueryable<SuperheroListDTO> Read();
        Task<HttpStatusCode> Update(SuperheroUpdateDTO superhero);
        Task<HttpStatusCode> Delete(int superheroId);
    }
}
