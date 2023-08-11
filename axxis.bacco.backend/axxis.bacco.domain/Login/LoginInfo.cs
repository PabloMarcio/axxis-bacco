using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.domain.Login
{
    public class LoginInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Notifications { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
