using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minamb.Application.DTO
{
    public class UtilizadorDTO : App
    {
        public string IdUtilizador { get; set; } = Guid.NewGuid().ToString();

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public List<string> Roles { get; set; }
    }
}
