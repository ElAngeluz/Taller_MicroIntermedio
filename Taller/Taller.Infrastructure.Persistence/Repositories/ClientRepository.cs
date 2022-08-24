using Microsoft.Extensions.Logging;
using Taller.Application.Interfaces.Repositories;
using Taller.Domain.Entities;
using Taller.Infrastructure.Persistence.Contexts;
using Taller.Infrastructure.Persistence.Repository;

namespace Taller.Infrastructure.Persistence.Repositories
{
    public class ClientRepository : GenericRepositoryAsync<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext dbContext, ILogger<ClientRepository> Logger) : base(dbContext, Logger)
        {
        }
    }
}
