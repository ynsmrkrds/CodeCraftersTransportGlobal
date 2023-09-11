using AutoMapper;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Application.ViewModels.UserContextViewModels;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;

namespace EventManagement.Application.Mappings
{
    public class EntityToViewModelMappings : Profile
    {
        public EntityToViewModelMappings()
        {
            #region User Bounded Context Mappings
            CreateMap<UserEntity, UserViewModel>();
            #endregion

            #region Transporter Bounded Context Mappings
            CreateMap<CompanyEntity, CompanyViewModel>();

            CreateMap<VehicleEntity, VehicleViewModel>();

            CreateMap<EmployeeEntity, EmployeeViewModel>();
            #endregion

            #region Transport Request Bounded Context Mappings
            CreateMap<TransportRequestEntity,TransportRequestViewModel>();
            #endregion

        }
    }
}
