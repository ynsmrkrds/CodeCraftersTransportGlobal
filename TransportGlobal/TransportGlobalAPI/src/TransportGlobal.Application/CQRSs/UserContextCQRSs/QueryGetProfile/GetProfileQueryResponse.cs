using TransportGlobal.Application.ViewModels.UserContextViewModels;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.QueryGetProfile
{
    public class GetProfileQueryResponse
    {
        public UserViewModel Profile { get; set; }

        public GetProfileQueryResponse(UserViewModel profile)
        {
            Profile = profile;
        }
    }
}
