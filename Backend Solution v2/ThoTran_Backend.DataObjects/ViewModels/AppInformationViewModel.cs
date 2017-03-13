using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.DataObjects.ViewModels
{
    public class AppInformationViewModel
    {
        [Display(Name = "Application ID")]
        public int Id { get; set; }
        [Display(Name = "Application Description")]
        public string Description { get; set; }
    }
}
