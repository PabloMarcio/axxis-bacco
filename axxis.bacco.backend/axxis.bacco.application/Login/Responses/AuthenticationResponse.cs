using axxis.bacco.domain.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.application.Login.Responses
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse(bool ok, string message, LoginInfo loginInfo)
        {
            Ok = ok;
            Message = message;
            LoginInfo = loginInfo;  
        }

        public bool Ok { get; set; }
        public string Message { get; set; }
        public LoginInfo LoginInfo { get; set; }
    }
}
