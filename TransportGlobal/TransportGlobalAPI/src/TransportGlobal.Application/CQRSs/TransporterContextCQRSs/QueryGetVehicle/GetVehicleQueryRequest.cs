using MediatR;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetVehicle
{
    public class GetVehicleQueryRequest : IRequest<GetVehicleQueryResponse>
    {
        public int ID { get; set; }

        public GetVehicleQueryRequest(int id)
        {
            ID = id;
        }
    }
}
