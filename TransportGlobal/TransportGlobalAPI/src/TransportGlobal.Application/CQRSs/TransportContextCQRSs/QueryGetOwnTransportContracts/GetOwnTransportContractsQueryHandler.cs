using AutoMapper;
using MediatR;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportContractsByUserType;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.ObjectExtensions;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportContracts
{
    public class GetOwnTransportContractsQueryHandler : IRequestHandler<GetOwnTransportContractsQueryRequest, GetOwnTransportContractsQueryResponse>
    {
        private readonly ITransportContractRepository _transportContractRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetOwnTransportContractsQueryHandler(ITransportContractRepository transportContractRepository, IUserRepository userRepository, IMapper mapper)
        {
            _transportContractRepository = transportContractRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<GetOwnTransportContractsQueryResponse> Handle(GetOwnTransportContractsQueryRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            List<TransportContractEntity> transportContracts = userEntity.Type switch
            {
                UserType.Shipper => _transportContractRepository.GetAllByCompanyID(userEntity.ActiveCompany!.ID).WithPagination(request.Pagination).ToList(),
                UserType.Customer => _transportContractRepository.GetAllByUserID(userID).WithPagination(request.Pagination).ToList(),
                _ => new()
            };

            List<TransportContractViewModel> transportContractViewModels = _mapper.Map<List<TransportContractViewModel>>(transportContracts);

            return Task.FromResult(new GetOwnTransportContractsQueryResponse(transportContractViewModels));
        }
    }
}
