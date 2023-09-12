using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.ReviewContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.ReviewContextRepositories;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandDeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommandRequest, DeleteReviewCommandResponse>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ITransportContractRepository _transportContractRepository;

        public DeleteReviewCommandHandler(IReviewRepository reviewRepository, ITransportContractRepository transportContractRepository)
        {
            _reviewRepository = reviewRepository;
            _transportContractRepository = transportContractRepository;
        }

        public Task<DeleteReviewCommandResponse> Handle(DeleteReviewCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);

            ReviewEntity reviewEntity = _reviewRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundReview);

            if (_transportContractRepository.IsOwner(reviewEntity.TransportContractID, userID) == false) return Task.FromResult(new DeleteReviewCommandResponse(ResponseConstants.NotTransportContractOwner));

            _reviewRepository.Delete(reviewEntity);

            int effectedRows = _reviewRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteReviewCommandResponse(ResponseConstants.DeleteFailed));

            return Task.FromResult(new DeleteReviewCommandResponse(ResponseConstants.SuccessfullyDeleted));
        }
    }
}
