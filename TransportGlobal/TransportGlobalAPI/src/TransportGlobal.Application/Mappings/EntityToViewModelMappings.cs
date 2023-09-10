using AutoMapper;
using TransportGlobal.Application.ViewModels.ReviewContextViewModels;
using TransportGlobal.Application.ViewModels.UserContextViewModels;
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

            #region Review Bounded Context Mappings
            CreateMap<ReviewEntity, ReviewViewModel>();
            #endregion
        }
    }
}
