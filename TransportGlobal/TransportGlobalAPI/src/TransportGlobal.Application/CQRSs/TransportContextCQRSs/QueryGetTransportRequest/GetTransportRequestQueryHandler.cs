using AutoMapper;
using MediatR;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandUpdateTransportRequest;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetTransportRequest
{
    public class GetTransportRequestQueryHandler : IRequestHandler<GetTransportRequestQueryRequest, GetTransportRequestQueryResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public GetTransportRequestQueryHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public Task<GetTransportRequestQueryResponse> Handle(GetTransportRequestQueryRequest request, CancellationToken cancellationToken)
        {
            //TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);
            TransportRequestEntity transportRequestEntity = _transportRequestRepository.GetByID(request.ID)!;
            TransportRequestViewModel transportRequestViewModel = _mapper.Map<TransportRequestViewModel>(transportRequestEntity);

            return Task.FromResult(new GetTransportRequestQueryResponse(transportRequestViewModel));
            
        }
    }
}
