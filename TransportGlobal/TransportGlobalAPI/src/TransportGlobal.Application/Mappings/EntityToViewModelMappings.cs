using AutoMapper;
using TransportGlobal.Application.ViewModels.MessagingContextViewModels;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Application.ViewModels.ReviewContextViewModels;
using TransportGlobal.Application.ViewModels.UserContextViewModels;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.ReviewContextEntities;
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
            CreateMap<TransportRequestEntity, TransportRequestViewModel>();

            CreateMap<TransportContractEntity, TransportContractViewModel>();
            #endregion

            #region Messaging Bounded Context Mappings
            CreateMap<ChatEntity, ChatViewModel>();

            CreateMap<MessageEntity, MessageViewModel>();
            #endregion

            #region Review Bounded Context Mappings
            CreateMap<ReviewEntity, ReviewViewModel>();
            #endregion
        }
    }
}
