using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _injDataContext;

        public UsersController(DataContext context)
        {
            _injDataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsersFromDb()
        {
            var allMyUsers = _injDataContext.AllMyUsers.ToListAsync();

            return await allMyUsers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetASingleUserFromDb(int id) 
        {
            var aUser = _injDataContext.AllMyUsers.FindAsync(id);

            return await aUser;
        }
    }
}