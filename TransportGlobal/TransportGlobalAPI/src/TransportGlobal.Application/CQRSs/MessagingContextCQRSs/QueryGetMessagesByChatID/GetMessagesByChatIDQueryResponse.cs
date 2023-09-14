using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Application.ViewModels.MessagingContextViewModels;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetMessagesByChatID
{
    public class GetMessagesByChatIDQueryResponse : BaseQueryListResponseDTO<MessageViewModel>
    {
        public GetMessagesByChatIDQueryResponse(IEnumerable<MessageViewModel> list, PaginationModel paginationModel) : base(list, paginationModel)
        {
        }
    }
}
