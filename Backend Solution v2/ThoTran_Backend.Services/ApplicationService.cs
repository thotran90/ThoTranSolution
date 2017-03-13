using System.Linq;
using $safeprojectname$.DataObjects.DataTransferObjects;
using $safeprojectname$.Domain.Core;
using $safeprojectname$.Repositories.Contracts;
using $safeprojectname$.Services.Contracts;
namespace $safeprojectname$.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IRepository<ApplicationInformation> _appInformationRepository;

        public ApplicationService(IRepository<ApplicationInformation> appInformationRepository)
        {
            this._appInformationRepository = appInformationRepository;
        }

        public AppInformationDto GetApp()
        => _appInformationRepository.Get().Select(x => new AppInformationDto()
        {
            AppId = x.AppId,
            Description = x.Description
        }).FirstOrDefault();
    }
}
