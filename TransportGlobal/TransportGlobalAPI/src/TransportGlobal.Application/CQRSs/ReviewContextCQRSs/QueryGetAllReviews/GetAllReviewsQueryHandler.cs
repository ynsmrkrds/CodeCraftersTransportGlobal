using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.ReviewContextViewModels;
using TransportGlobal.Domain.Entities.ReviewContextEntities;
using TransportGlobal.Domain.Repositories.ReviewContextRepositories;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.QueryGetAllReviews
{
    public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQueryRequest, GetAllReviewsQueryResponse>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public GetAllReviewsQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public Task<GetAllReviewsQueryResponse> Handle(GetAllReviewsQueryRequest request, CancellationToken cancellationToken)
        {
            List<ReviewEntity> reviews = _reviewRepository.GetAll().ToList();

            List<ReviewViewModel> viewModels = _mapper.Map<List<ReviewEntity>, List<ReviewViewModel>>(reviews);

            return Task.FromResult(new GetAllReviewsQueryResponse(viewModels));
        }
    }
}
