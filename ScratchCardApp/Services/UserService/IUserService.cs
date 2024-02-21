using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScratchCardApp.Dtos.User;

namespace ScratchCardApp.Services.UserService
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        UserDto GetUserById(Guid id);
        UserDto CreateUser(CreateUserDto createUserDto);
        UserDto UpdateUser(Guid id, UpdateUserDto updateUserDto);
        bool DeleteUser(Guid id);
    }
}