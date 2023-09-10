using MediatR;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.ReviewContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.ReviewContextRepositories;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandDeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommandRequest, DeleteReviewCommandResponse>
    {
        private readonly IReviewRepository _reviewRepository;

        public DeleteReviewCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task<DeleteReviewCommandResponse> Handle(DeleteReviewCommandRequest request, CancellationToken cancellationToken)
        {
            /* TODO:
             * Silinmek istenilen değerlendirmenin Transport'una ait Transport Request'te yer alan kullanıcı 
             * ile değerlendirmeyi silen kullanıcı aynı değil ise işleme devam edilmez.
             */

            ReviewEntity reviewEntity = _reviewRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundReview);
            _reviewRepository.Delete(reviewEntity);

            int effectedRows = _reviewRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteReviewCommandResponse(ResponseConstants.DeleteFailed));

            return Task.FromResult(new DeleteReviewCommandResponse(ResponseConstants.SuccessfullyDeleted));
        }
    }
}
