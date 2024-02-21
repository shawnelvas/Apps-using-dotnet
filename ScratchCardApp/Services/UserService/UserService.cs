using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScratchCardApp.Dtos.User;

namespace ScratchCardApp.Services.UserService
{
    public class UserService : IUserService
    {
        public UserDto CreateUser(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            throw new NotImplementedException();
        }

        public UserDto UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}