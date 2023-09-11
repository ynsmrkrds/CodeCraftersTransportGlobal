using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetPendingTransportRequests;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.ObjectExtensions;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportRequests
{
    public class GetOwnTransportRequestsQueryHandler : IRequestHandler<GetOwnTransportRequestsQueryRequest, GetOwnTransportRequestsQueryResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public GetOwnTransportRequestsQueryHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public Task<GetOwnTransportRequestsQueryResponse> Handle(GetOwnTransportRequestsQueryRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            List<TransportRequestEntity> transportRequestEntities = _transportRequestRepository.GetTransportRequestsByUserID(tokenModel.UserID).WithPagination(request.Pagination).ToList();

            List<TransportRequestViewModel> transportRequestViewModels = _mapper.Map<List<TransportRequestViewModel>>(transportRequestEntities);

            return Task.FromResult(new GetOwnTransportRequestsQueryResponse(transportRequestViewModels));
        }
    }
}
