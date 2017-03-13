using System.ComponentModel.DataAnnotations;
using $safeprojectname$.Resources;

namespace $safeprojectname$.DataObjects.ViewModels
{
    public class LoginViewModel
    {
        [Display(ResourceType = typeof(language), Name = "LoginId")]
        public string LoginId { get; set; }
        [Display(ResourceType = typeof(language), Name = "Password")]
        public string Password { get; set; }
    }
}
