using MediatR;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandAgreeTransportContract
{
    public class AgreeTransportContractCommandRequest : IRequest<AgreeTransportContractCommandResponse>
    {
        public int ID { get; set; }

        public AgreeTransportContractCommandRequest(int id)
        {
            ID = id;
        }
    }
}
