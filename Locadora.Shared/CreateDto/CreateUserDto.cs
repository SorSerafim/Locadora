using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Shared.CreateDto
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
