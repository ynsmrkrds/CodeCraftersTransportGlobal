using AutoMapper;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandCreateCompany;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandCreateEmployee;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandCreateVehicle;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandUpdateCompany;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandUpdateVehicle;
using TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandCreateUser;
using TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandUpdateUser;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Enums.CompanyContextEntities;

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

            #region Company Bounded Context Mappings
            CreateMap<CreateCompanyCommandRequest, CompanyEntity>();

            CreateMap<UpdateCompanyCommandRequest, CompanyEntity>();

            CreateMap<CreateVehicleCommandRequest, VehicleEntity>()
                .ConstructUsing(src => new VehicleEntity(0, src.IdentificationNumber, src.Type, VehicleStatusType.NotWorking, false));

            CreateMap<UpdateVehicleCommandRequest, VehicleEntity>();

            CreateMap<CreateEmployeeCommandRequest, EmployeeEntity>();
            #endregion
        }
    }
}
