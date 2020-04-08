using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Api.Data;
using Web.Api.Data.Infrastructure.Repository;
using Web.Api.Data.Infrastructure.Repository.IAppUsersRepositiry;
using Web.Api.Domain;
using Web.Api.DtoModels;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly BdContext _context;

        private readonly IAppUserRepository _appUserRepository;
        private readonly IUnitOfWork<AppUser> _unitOfWorkAppUser;
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;

        public AppUsersController(BdContext context, IAppUserRepository appUserRepository, IUnitOfWork<AppUser> unitOfWorkAppUser, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _unitOfWorkAppUser = unitOfWorkAppUser;
            _cancellationToken = new CancellationToken();
            _mapper = mapper;
            _context = context;
        }

        // GET: api/AppUsers
        [HttpGet]
        public async Task<IEnumerable<AppUserDto>> GetAppUsers()
        {
            return _mapper.Map<IEnumerable<AppUserDto>>(await _appUserRepository.FindAppUsersWithOrderAsync());
            //return await _context.AppUsers.ToListAsync();
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetAppUser(string id)
        {
            var appUser = await _appUserRepository.FindAppUserWithOrderAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(string id, AppUser appUser)
        {
            if (id != appUser.AppUserId)
            {
                return BadRequest();
            }

            _context.Entry(appUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AppUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(AppUser appUser)
        {
            _context.AppUsers.Add(appUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppUser", new { id = appUser.AppUserId }, appUser);
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppUser>> DeleteAppUser(string id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();

            return appUser;
        }

        private bool AppUserExists(string id)
        {
            return _context.AppUsers.Any(e => e.AppUserId == id);
        }
    }
}
