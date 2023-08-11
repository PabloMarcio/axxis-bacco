using axxis.bacco.application.Login.Requests;
using axxis.bacco.application.Login.Responses;

namespace axxis.bacco.application.Login.Interfaces
{
    public interface ILoginService
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);        
    }
}
