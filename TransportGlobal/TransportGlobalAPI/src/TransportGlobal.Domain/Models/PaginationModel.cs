namespace TransportGlobal.Domain.Models
{
    public class PaginationModel
    {
        public int Page { get; private set; }

        public int Size { get; private set; }

        public PaginationModel(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}
