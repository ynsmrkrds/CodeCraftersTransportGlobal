using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.ObjectExtensions;

namespace TransportGlobal.Application.DTOs.CQRSDTOs
{
    public class BaseQueryListResponseDTO<T>
    {
        public ICollection<T> List { get; set; }

        public int TotalCount { get; set; }

        public BaseQueryListResponseDTO(IEnumerable<T> list, PaginationModel paginationModel)
        {
            List = list.WithPagination(paginationModel).ToList();
            TotalCount = list.Count();
        }
    }
}
