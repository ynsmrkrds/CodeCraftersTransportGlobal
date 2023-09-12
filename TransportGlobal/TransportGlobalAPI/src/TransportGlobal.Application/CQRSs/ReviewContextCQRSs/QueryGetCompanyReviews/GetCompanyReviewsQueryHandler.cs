using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.ReviewContextViewModels;
using TransportGlobal.Domain.Entities.ReviewContextEntities;
using TransportGlobal.Domain.ObjectExtensions;
using TransportGlobal.Domain.Repositories.ReviewContextRepositories;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.QueryGetCompanyReviews
{
    public class GetCompanyReviewsQueryHandler : IRequestHandler<GetCompanyReviewsQueryRequest, GetCompanyReviewsQueryResponse>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public GetCompanyReviewsQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public Task<GetCompanyReviewsQueryResponse> Handle(GetCompanyReviewsQueryRequest request, CancellationToken cancellationToken)
        {
            List<ReviewEntity> reviews = _reviewRepository.GetReviewsByCompanyID(request.CompanyID).WithPagination(request.Pagination).ToList();

            List<ReviewViewModel> viewModels = _mapper.Map<List<ReviewViewModel>>(reviews);

            return Task.FromResult(new GetCompanyReviewsQueryResponse(viewModels));
        }
    }
}
