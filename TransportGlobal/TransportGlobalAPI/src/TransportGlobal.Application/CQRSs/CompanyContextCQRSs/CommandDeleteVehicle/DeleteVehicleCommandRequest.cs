using MediatR;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandDeleteVehicle
{
    public class DeleteVehicleCommandRequest : IRequest<DeleteVehicleCommandResponse>
    {
        public int ID { get; set; }

        public DeleteVehicleCommandRequest(int id)
        {
            ID = id;
        }
    }
}
