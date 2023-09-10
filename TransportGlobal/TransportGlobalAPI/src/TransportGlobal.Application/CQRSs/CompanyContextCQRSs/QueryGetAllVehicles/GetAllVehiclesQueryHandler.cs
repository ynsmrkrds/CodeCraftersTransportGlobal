using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.CompanyContextViewModels;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.ObjectExtensions;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllVehicles
{
    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQueryRequest, GetAllVehiclesQueryResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllVehiclesQueryHandler(IVehicleRepository vehicleRepository, IUserRepository userRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<GetAllVehiclesQueryResponse> Handle(GetAllVehiclesQueryRequest request, CancellationToken cancellationToken)
        {
            List<VehicleEntity> vehicles;

            if (request.CompanyID != null)
            {
                vehicles = _vehicleRepository.GetAllByCompanyID((int)request.CompanyID).WithPagination(request.Pagination).ToList();
            }
            else
            {
                vehicles = _vehicleRepository.GetAll().AsEnumerable().WithPagination(request.Pagination).ToList();
            }

            List<VehicleViewModel> viewModels = _mapper.Map<List<VehicleEntity>, List<VehicleViewModel>>(vehicles);

            return Task.FromResult(new GetAllVehiclesQueryResponse(viewModels));
        }
    }
}
