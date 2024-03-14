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


        [HttpGet("{UserId}")]
        public async Task<ActionResult<UserDto>> GetUserId(int UserId)
        {
            try
            {
                var user = await _context.Users.FindAsync(UserId);

                if (user == null)
                {
                    var errorResponse = new
                    {
                        statusCode = 404,
                        remarks = "User not found",
                        data = new
                        {
                           UserId = UserId  
                        },
                        errors = ""
                    };

                    return NotFound(errorResponse);
                }
                var response = new
                {
                    statusCode = 200,
                    remarks = "Success",
                    data = new
                    {
                        
                        userId = user.UserId,
                        firstName = user.FirstName, 
                        lastName = user.LastName,
                        email  = user.Email,
                        usertype = user.UserType,

                    },
                    errors = ""
                };

                return Ok(response);

            }
            catch (Exception ex)
            {
               return StatusCode(500, ex.Message);
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



        [HttpDelete("{UserId}")]
        public async Task<ActionResult<UserDto>> DeleteUser(int UserId)
        {
            try
            {
                var user = await _context.Users.FindAsync(UserId);
                if (user == null)
                {
                    var errorResponse = new
                    {
                        StatusCode = 404,
                        Remarks  = $"User With ID {UserId} not found",
                        Data  =  new
                        {
                            userId =  UserId,
                        },
                        Errors = "",
                    };
                    return NotFound(errorResponse);
                }
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                var response = new
                {
                    StatusCode = 200,
                    Remarks = $"User With ID {UserId} Deleted",
                    Data = new
                    {
                        userId = UserId,
                        firstname  = user.FirstName,
                        lastname = user.LastName,
                        email = user.Email,
                        usertype = user.UserType,
                    },
                    Errors = "",
                };
                return Ok(response);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, UserDto userDto)
        //{
        //    if (id != userDto.UserId)
        //    {
        //        return BadRequest();
        //    }


        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
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

        //private bool UserExists(int UserId)
        //{
        //    return _context.Users.Any(e => e.UserId == UserId);
        //}


    }
}
