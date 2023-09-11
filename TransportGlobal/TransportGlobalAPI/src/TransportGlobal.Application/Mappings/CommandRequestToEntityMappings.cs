using AutoMapper;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateCompany;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateEmployee;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateVehicle;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateCompany;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateEmployee;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateVehicle;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransport;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportRequest;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandUpdateTransportRequest;
using TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandCreateUser;
using TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandUpdateUser;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Enums.TransporterContextEnums;
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

            #region Transporter Bounded Context Mappings
            CreateMap<CreateCompanyCommandRequest, CompanyEntity>();

            CreateMap<UpdateCompanyCommandRequest, CompanyEntity>();

            CreateMap<CreateVehicleCommandRequest, VehicleEntity>()
                .ConstructUsing(src => new VehicleEntity(0, src.IdentificationNumber, src.Type, VehicleStatusType.NotWorking, false));

            CreateMap<UpdateVehicleCommandRequest, VehicleEntity>();

            CreateMap<CreateEmployeeCommandRequest, EmployeeEntity>()
                 .ConstructUsing(src => new EmployeeEntity(0, src.VehicleID ?? null, src.Name, src.Surname, src.Email, src.Title, false));

            CreateMap<UpdateEmployeeCommandRequest, EmployeeEntity>()
                 .ConstructUsing(src => new EmployeeEntity(0, src.VehicleID ?? null, src.Name, src.Surname, src.Email, src.Title, false));
            #endregion

            #region Transport Bounded Context Mappings
            CreateMap<CreateTransportRequestCommandRequest, TransportRequestEntity>()
                .ConstructUsing(src => new TransportRequestEntity(0, src.TransportType, src.Weight, src.Volume, src.TransportDate, src.LoadingAddress, src.DeliveryAddress, StatusType.Pending));
            
            CreateMap<UpdateTransportRequestCommandRequest, TransportRequestEntity>();

            CreateMap<CreateTransportCommandRequest, TransportEntity>();
            #endregion
        }
    }
}
