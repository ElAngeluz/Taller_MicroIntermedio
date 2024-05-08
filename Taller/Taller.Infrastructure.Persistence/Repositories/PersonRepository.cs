using Microsoft.Extensions.Logging;
using Taller.Application.Interfaces.Repositories;
using Taller.Domain.Entities;
using Taller.Infrastructure.Persistence.Contexts;

namespace Taller.Infrastructure.Persistence.Repositories
{
    public class PersonRepository : GenericRepositoryAsync<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext dbContext, ILogger<PersonRepository> Logger) : base(dbContext, Logger)
        {
        }
    }
}
