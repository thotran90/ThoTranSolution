using $safeprojectname$.Arguments;
using $safeprojectname$.DataTransferObjects;
using $safeprojectname$;

namespace $safeprojectname$
{
    public class UserService : IUserService
    {
    public $safeprojectname$.DataTransferObjects.UserDto LoginByPassword($safeprojectname$.Arguments.LoginArgument arg)
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
