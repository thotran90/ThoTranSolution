namespace Web.Models
{
    public class ApplicationState
    {
        public string Email = string.Empty;
        public string LoginId = string.Empty;
        public int UserId;
        public string UserName = string.Empty;
        /// <summary>
        ///     Exports a short string list of Id, Email, Name separated by |
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join("|", LoginId, UserName);
        }

        /// <summary>
        ///     Imports Id, Email and Name from a | separated string
        /// </summary>
        /// <param name="itemString"></param>
        public bool FromString(string itemString)
        {
            if (string.IsNullOrEmpty(itemString))
                return false;

            var strings = itemString.Split('|');
            if (strings.Length < 3)
                return false;

            LoginId = strings[0];
            UserName = strings[1];
            return true;
        }

        /// <summary>
        ///     Populates the AppUserState properties from a
        ///     User instance
        /// </summary>
        /// <param name="user"></param>
        /*
        public void FromUser(UserViewModel user)
        {
            LoginId = user.LoginId;
            UserId = user.UserId;
            UserName = user.UserName;
            Email = user.Email;
            CompanyId = user.CompanyId;
        }*/


        /// <summary>
        ///     Determines if the user is logged in
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(LoginId) || string.IsNullOrEmpty(UserName))
                return true;

            return false;
        }
    }
}