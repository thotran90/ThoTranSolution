using $safeprojectname$.DataObjects.Arguments;
using $safeprojectname$.DataObjects.DataTransferObjects;

namespace $safeprojectname$.Services.Contracts
{
    public interface IUserService
    {
        UserDto LoginByPassword(LoginArgument arg);
    }
}
