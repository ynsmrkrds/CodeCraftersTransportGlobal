using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Application.ViewModels.MessagingContextViewModels;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetOwnChats
{
    public class GetOwnChatsQueryResponse : BaseQueryListResponseDTO<ChatViewModel>
    {
        public GetOwnChatsQueryResponse(IEnumerable<ChatViewModel> list, PaginationModel paginationModel) : base(list, paginationModel)
        {
        }
    }
}
