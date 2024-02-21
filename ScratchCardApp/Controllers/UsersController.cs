using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScratchCardApp.Dtos.User;
using ScratchCardApp.Services.UserService;



namespace ScratchCardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
     private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUserById(Guid id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser(CreateUserDto createUserDto)
        {
            var createdUser = _userService.CreateUser(createUserDto);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var result = _userService.UpdateUser(id, updateUserDto);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var result = _userService.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

   
}