using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.ViewModels
{
    public class LoginViewModel
{
    [Display(ResourceType = typeof(language), Name = "LoginId")]
    public string LoginId { get; set; }
    [Display(ResourceType = typeof(language), Name = "Password")]
    public string Password { get; set; }
}
}
