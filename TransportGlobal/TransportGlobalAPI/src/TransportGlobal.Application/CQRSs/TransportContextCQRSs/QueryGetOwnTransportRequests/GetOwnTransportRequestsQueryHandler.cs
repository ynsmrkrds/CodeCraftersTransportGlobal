﻿using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
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

            IEnumerable<TransportRequestEntity> transportRequestEntities = _transportRequestRepository.GetTransportRequestsByUserID(tokenModel.UserID);

            IEnumerable<TransportRequestViewModel> transportRequestViewModels = _mapper.Map<IEnumerable<TransportRequestViewModel>>(transportRequestEntities);

            return Task.FromResult(new GetOwnTransportRequestsQueryResponse(transportRequestViewModels, request.Pagination));
        }
    }
}
