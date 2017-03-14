using System.Linq;

namespace $safeprojectname$
{
    public class ApplicationService : $safeprojectname$.IApplicationService
    {
        private readonly IRepository<$safeprojectname$.Core.ApplicationInformation> _appInformationRepository;

        public ApplicationService(IRepository<$safeprojectname$.Core.ApplicationInformation> appInformationRepository)
        {
            this._appInformationRepository = appInformationRepository;
        }

    public $safeprojectname$.DataTransferObjects.AppInformationDto GetApp()
        => _appInformationRepository.Get().Select(x => new $safeprojectname$.DataTransferObjects.AppInformationDto()
        {
            AppId = x.AppId,
            Description = x.Description
        }).FirstOrDefault();
    }
}
