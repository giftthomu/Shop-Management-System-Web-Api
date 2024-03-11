using CRUD_WEB_API.Data;
using CRUD_WEB_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_WEB_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CrudWebApiContext _context;

       
        public UsersController(CrudWebApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{Id}")]
        
        public async Task<ActionResult<Users>> GetUser(int Id)
        {
            var user = await _context.Users.FindAsync(Id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
       
    }
}
