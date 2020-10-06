using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lecture07.Models
{
    public interface ISuperheroRepository
    {
        Task<int> Create(SuperheroCreateDTO superhero);
        Task<SuperheroDetailsDTO> Read(int superheroId);
        Task<ICollection<SuperheroListDTO>> Read();
        Task<Response> Update(SuperheroUpdateDTO superhero);
        Task<Response> Delete(int superheroId);
    }
}
