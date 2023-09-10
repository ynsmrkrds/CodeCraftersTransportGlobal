using AutoMapper;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransport;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportRequest;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandUpdateTransportRequest;
using TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandCreateUser;
using TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandUpdateUser;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Enums.TransportContextEnums;

namespace TransportGlobal.Application.Mappings
{
    public class CommandRequestToEntityMappings : Profile
    {
        public CommandRequestToEntityMappings()
        {
            #region User Bounded Context Mappings
            CreateMap<CreateUserCommandRequest, UserEntity>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ConstructUsing(src => new UserEntity(src.Name, src.Surname, src.Email, src.Password, src.Type));

            CreateMap<UpdateUserCommandRequest, UserEntity>();
            #endregion

            #region Transport Request Bounded Context Mappings
            CreateMap<CreateTransportRequestCommandRequest, TransportRequestEntity>().ConstructUsing(src => new TransportRequestEntity(0, src.TransportType, src.Weight, src.Volume, src.TransportDate, src.RequestDate, src.LoadingAddress, src.DeliveryAddress, StatusType.Pending));
            CreateMap<UpdateTransportRequestCommandRequest, TransportRequestEntity>();
            #endregion

            #region Transport Bounded Context Mappings
            CreateMap<CreateTransportCommandRequest, TransportEntity>();
            #endregion
        }
    }
}
