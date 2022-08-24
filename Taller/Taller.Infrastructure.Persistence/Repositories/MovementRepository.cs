using Microsoft.Extensions.Logging;
using Taller.Application.Interfaces.Repositories;
using Taller.Domain.Entities;
using Taller.Infrastructure.Persistence.Contexts;
using Taller.Infrastructure.Persistence.Repository;

namespace Taller.Infrastructure.Persistence.Repositories
{
    public class MovementRepository : GenericRepositoryAsync<Movement>, IMovementRepository
    {
        public MovementRepository(ApplicationDbContext dbContext, ILogger<MovementRepository> Logger) : base(dbContext, Logger)
        {
        }
    }
}
