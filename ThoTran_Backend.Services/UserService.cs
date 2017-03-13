using $safeprojectname$.DataObjects.Arguments;
using $safeprojectname$.DataObjects.DataTransferObjects;
using $safeprojectname$.Services.Contracts;

namespace $safeprojectname$.Services
{
    public class UserService : IUserService
    {
        public UserDto LoginByPassword(LoginArgument arg)
        {
            return new UserDto()
            {
                UserId = 1,
                LoginId = "admin",
                Email = "admin@abc.com",
                UserName = "Administrator"
            };
        }
    }
}
