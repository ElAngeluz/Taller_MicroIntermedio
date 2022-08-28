using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.Application.Interfaces.Repositories;
using Taller.Domain.Entities;
using Taller.Infrastructure.Persistence.Contexts;
using Taller.Infrastructure.Persistence.Repository;

namespace Taller.Infrastructure.Persistence.Repositories
{
    public class ClientRepository : GenericRepositoryAsync<Client>, IClientRepository
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;
        public ClientRepository(ApplicationDbContext dbContext, ILogger<ClientRepository> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public override async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _dbContext.Client
                .Include(c => c.PersonNav)
                .Include(c=> c.AccountsNav)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Client> GetByIdAsync(Guid id)
        {
            return await _dbContext.Client
                .Include(c => c.PersonNav)
                .Include(c => c.AccountsNav)
                .FirstAsync(c=>c.ClientId == id);
        }
    }
}
