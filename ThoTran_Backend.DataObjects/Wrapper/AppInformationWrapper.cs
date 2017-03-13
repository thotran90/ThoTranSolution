using System.Linq;
using $safeprojectname$.DataObjects.DataTransferObjects;
using $safeprojectname$.DataObjects.ViewModels;

namespace $safeprojectname$.DataObjects.Wrapper
{
    public class AppInformationWrapper
    {
        private AppInformationDto _dto;
        private IQueryable<AppInformationDto> _list;
        public AppInformationWrapper(AppInformationDto dto)
        {
            this._dto = dto;
        }

        public AppInformationWrapper(IQueryable<AppInformationDto> list)
        {
            this._list = list;
        }

        public AppInformationViewModel ToViewModel()
        {
            if (_dto == null) return new AppInformationViewModel();
            var result = new AppInformationViewModel()
            {
                Id = _dto.AppId,
                Description = _dto.Description
            };
            return result;
        }

        public IQueryable<AppInformationViewModel> ProjectToViewModel()
            => _list.Select(x => new AppInformationViewModel()
            {
                Id = x.AppId,
                Description = x.Description
            });
    }
}
