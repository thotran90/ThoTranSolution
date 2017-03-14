using $safeprojectname$.Arguments;
using $safeprojectname$.DataTransferObjects;

namespace $safeprojectname$
{
    public interface IUserService
    {
        UserDto LoginByPassword(LoginArgument arg);
    }
}
