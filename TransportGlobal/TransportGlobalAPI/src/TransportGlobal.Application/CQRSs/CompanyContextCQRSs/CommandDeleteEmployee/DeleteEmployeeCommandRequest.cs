using MediatR;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandDeleteEmployee
{
    public class DeleteEmployeeCommandRequest : IRequest<DeleteEmployeeCommandResponse>
    {
        public int ID { get; set; }

        public DeleteEmployeeCommandRequest(int id)
        {
            ID = id;
        }
    }
}
