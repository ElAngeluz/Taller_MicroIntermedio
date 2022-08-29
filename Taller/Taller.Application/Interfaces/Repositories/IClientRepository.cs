using System.Threading.Tasks;
using Taller.Domain.Entities;

namespace Taller.Application.Interfaces.Repositories
{
    public interface IClientRepository : IGenericRepositoryAsync<Client>
    {
        Task<Client> GetByIdAsync(string id);
    }
}
