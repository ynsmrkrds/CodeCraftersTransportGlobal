using MediatR;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandDeleteEmployee
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
