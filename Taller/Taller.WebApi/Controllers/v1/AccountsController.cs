using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Taller.Application.DTOs.Accounts;
using Taller.Application.Interfaces.Repositories;
using Taller.Domain.Entities;
using Taller.Infrastructure.Persistence.Contexts;

namespace Taller.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("/cuentas")]
    public class AccountsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _IAccountRepository;
        private readonly ILogger _logger;

        public AccountsController(IAccountRepository iAccountRepository,
                                  ILogger logger,
                                  IMapper mapper)
        {
            _IAccountRepository = iAccountRepository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountResponseDTO>>> GetAccount()
        {
            var result = await _IAccountRepository.GetAllAsync();
            var mappedUser = _mapper.Map<List<AccountResponseDTO>>(result);
            return Ok(mappedUser);
        }

        //// GET: api/Accounts/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Account>> GetAccount(Guid id)
        //{
        //    var account = await _context.Account.FindAsync(id);

        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    return account;
        //}

        //// PUT: api/Accounts/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAccount(Guid id, Account account)
        //{
        //    if (id != account.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(account).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AccountExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Accounts
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Account>> PostAccount(Account account)
        //{
        //    _context.Account.Add(account);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        //}

        //// DELETE: api/Accounts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAccount(Guid id)
        //{
        //    var account = await _context.Account.FindAsync(id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Account.Remove(account);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AccountExists(Guid id)
        //{
        //    return _context.Account.Any(e => e.Id == id);
        //}
    }
}
