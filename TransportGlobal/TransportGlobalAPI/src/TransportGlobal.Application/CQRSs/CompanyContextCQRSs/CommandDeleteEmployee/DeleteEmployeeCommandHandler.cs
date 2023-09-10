using MediatR;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandDeleteEmployee;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.CommandDeleteLocation
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            EmployeeEntity employeeEntity = _employeeRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundEmployee);
            if (employeeEntity.CompanyID != userEntity.Company?.ID) return Task.FromResult(new DeleteEmployeeCommandResponse(ResponseConstants.NotEmployeeOwner));

            _employeeRepository.Delete(employeeEntity);

            int effectedRows = _employeeRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteEmployeeCommandResponse(ResponseConstants.DeleteFailed));

            return Task.FromResult(new DeleteEmployeeCommandResponse(ResponseConstants.SuccessfullyDeleted));
        }
    }
}
