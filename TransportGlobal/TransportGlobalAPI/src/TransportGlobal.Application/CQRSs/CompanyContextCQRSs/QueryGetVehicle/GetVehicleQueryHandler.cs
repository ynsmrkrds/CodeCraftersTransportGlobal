using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.CompanyContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetVehicle
{
    public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQueryRequest, GetVehicleQueryResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public GetVehicleQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public Task<GetVehicleQueryResponse> Handle(GetVehicleQueryRequest request, CancellationToken cancellationToken)
        {
            VehicleEntity vehicleEntity = _vehicleRepository.GetByID(request.ID) ?? throw new ClientSideException(ResponseConstants.NotVehicleOwner.Message);

            VehicleViewModel vehicleViewModel = _mapper.Map<VehicleEntity, VehicleViewModel>(vehicleEntity);

            return Task.FromResult(new GetVehicleQueryResponse(vehicleViewModel));
        }
    }
}
