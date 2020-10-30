using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lecture09.App.Services
{
    public interface IRestClient
    {
        Task<IEnumerable<T>> GetAllAsync<T>(string resource);
        Task<T> GetAsync<T>(string resource);
        Task<Uri> PostAsync<T>(string resource, T item);
        Task<bool> PutAsync<T>(string resource, T item);
        Task<bool> DeleteAsync(string resource);
    }
}
