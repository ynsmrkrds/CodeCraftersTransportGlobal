using AutoMapper;
using MediatR;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.ReviewContextEntities;
using TransportGlobal.Domain.Repositories.ReviewContextRepositories;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandCreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, CreateReviewCommandResponse>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public Task<CreateReviewCommandResponse> Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            /* TODO:
             * Değerlendirme yapılmak istenilen Transport'a ait Transport Request'te yer alan kullanıcı ile 
             * değerlendirmeyi yapan kullanıcı aynı değil ise işleme devam edilmez.
             */

            /* TODO:
             * Değerlendirme yapılmak istenilen Transport'a ait aynı kullanıcının değerlendirmesi var ise
             * tekrar değerlendirme yapılamaz.
             */

            if (request.Score > 5 || request.Score < 1) return Task.FromResult(new CreateReviewCommandResponse(ResponseConstants.ReviewScoreOutOfRange));

            ReviewEntity reviewEntity = _mapper.Map<CreateReviewCommandRequest, ReviewEntity>(request);
            _reviewRepository.Add(reviewEntity);

            int effectedRows = _reviewRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateReviewCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateReviewCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
