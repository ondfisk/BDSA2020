using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lecture06.Models
{
    public interface ISuperheroRepository
    {
        int Create(SuperheroCreateDTO superhero);
        SuperheroDetailsDTO Read(int superheroId);
        ICollection<SuperheroListDTO> Read();
        Response Update(SuperheroUpdateDTO superhero);
        Response Delete(int superheroId);
    }
}
