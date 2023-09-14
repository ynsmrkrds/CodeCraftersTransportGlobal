using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.QueryGetToken
{
    public class GetTokenQueryRequest : IRequest<GetTokenQueryResponse>
    {
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }

        public string Password { get; set; }

        public GetTokenQueryRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
