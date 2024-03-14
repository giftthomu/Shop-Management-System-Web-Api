using Shop_Management_WEB_API.Data;
using Shop_Management_WEB_API.DTOs.Users;
using Shop_Management_WEB_API.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Shop_Management_WEB_API.DTOs.Inventory;
using Shop_Management_WEB_API.Models.Inventory;


namespace Shop_Management_WEB_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ShopWebApiContext _context;
        private readonly IMapper _mapper;

        public UsersController(ShopWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(405)] 
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return userDtos;
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<UserDto>> GetUserId(int UserId)
        {
            var user = await _context.Users.FindAsync(UserId);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> AddNewUser(UserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = new Users
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    UserType = userDto.UserType
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Prepare the response
                var response = new
                {
                    StatusCode = 200,
                    Remark = "User added successfully",
                    Data = new
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Email = userDto.Email,
                        UserType = userDto.UserType
                    },
                    Errors = ""
                };

                return Ok(response);

            }
            catch (Exception ex)
            {
               
                var errorResponse = new
                {
                    StatusCode = 500,
                    Remark = "Internal Server Error",
                    Data = new
                    {
                        FirstName = "",
                        LastName = "",
                        Email = "",
                        UserType = ""
                    },
                    Errors = ex.Message 
                };

                return StatusCode(500, errorResponse);
            }
        }



        [HttpDelete("{Id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(int Id)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDto userDto)
        {
            if (id != userDto.UserId)
            {
                return BadRequest();
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        private bool UserExists(int UserId)
        {
            return _context.Users.Any(e => e.UserId == UserId);
        }


    }
}
