using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minamb.Application
{
    public class RolesApp: App
    {
        public List<string> ListarRoles()
        {
            return db.AspNetRoles.Select(x => x.Name).ToList();
        }
    }
}
