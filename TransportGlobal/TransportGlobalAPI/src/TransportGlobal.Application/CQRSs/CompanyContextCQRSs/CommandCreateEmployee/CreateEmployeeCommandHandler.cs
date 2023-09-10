using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandCreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, CreateEmployeeCommandResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUserRepository userRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            if (userEntity.Company?.Vehicles.Any(x => x.ID == request.VehicleID) == false) return Task.FromResult(new CreateEmployeeCommandResponse(ResponseConstants.NotVehicleOwner));

            if (_employeeRepository.IsExistsWithSameEmail(request.Email)) return Task.FromResult(new CreateEmployeeCommandResponse(ResponseConstants.ExistsEmployeeWithSameEmail));

            EmployeeEntity employeeEntity = _mapper.Map<CreateEmployeeCommandRequest, EmployeeEntity>(request);
            _employeeRepository.Add(employeeEntity);

            int effectedRows = _employeeRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateEmployeeCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateEmployeeCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
