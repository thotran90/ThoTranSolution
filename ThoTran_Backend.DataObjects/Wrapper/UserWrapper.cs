namespace $safeprojectname$.Wrapper
{
    public class UserWrapper
{
    private readonly UserDto _user;

    public UserWrapper(UserDto user)
    {
        _user = user;
    }

    public UserViewModel ToViewModel()
    {
        if (_user == null) return new UserViewModel();
        var result = new UserViewModel
        {
            LoginId = _user.LoginId,
            Email = _user.Email,
            UserId = _user.UserId,
            UserName = _user.UserName
        };
        return result;
    }
}
}