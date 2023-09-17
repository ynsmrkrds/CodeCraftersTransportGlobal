using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnVehicles
{
    public class GetOwnVehiclesQueryHandler : IRequestHandler<GetOwnVehiclesQueryRequest, GetOwnVehiclesQueryResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICompanyRepository _companyRepository;

        private readonly IMapper _mapper;

        public GetOwnVehiclesQueryHandler(IVehicleRepository vehicleRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public Task<GetOwnVehiclesQueryResponse> Handle(GetOwnVehiclesQueryRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);

            CompanyEntity companyEntity = _companyRepository.GetCompanyByUserID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundCompany);

            IEnumerable<VehicleEntity> vehicles = _vehicleRepository.GetAllByCompanyID(companyEntity.ID);

            IEnumerable<VehicleViewModel> viewModels = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicles);

            return Task.FromResult(new GetOwnVehiclesQueryResponse(viewModels, request.Pagination));
        }
    }
}
