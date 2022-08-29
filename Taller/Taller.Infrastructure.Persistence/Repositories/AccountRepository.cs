using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taller.Application.Interfaces.Repositories;
using Taller.Domain.Entities;
using Taller.Infrastructure.Persistence.Contexts;
using Taller.Infrastructure.Persistence.Repository;

namespace Taller.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : GenericRepositoryAsync<Account>, IAccountRepository
    {
        private readonly ILogger<AccountRepository> _logger;
        public readonly ApplicationDbContext _dbContext;
        public AccountRepository(ApplicationDbContext dbContext, ILogger<AccountRepository> Logger) : base(dbContext, Logger)
        {
            _logger = Logger;
            _dbContext = dbContext;
        }

        public override async Task<IEnumerable<Account>> GetAllAsync() => 
            await _dbContext.Account
                        .Include(c => c.ClientNav)
                            .ThenInclude(t=> t.PersonNav)
                        .AsNoTracking()
                        .ToListAsync();

    }
}
