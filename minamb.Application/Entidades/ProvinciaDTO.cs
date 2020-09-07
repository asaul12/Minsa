using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minamb.Application.Entidades
{
    public class ProvinciaDTO
    {
        public int IdProvincia { get; set; }

        public string NomeProvincia { get; set; }

        public List<MunicipioDTO> Municipios { get; set; }
    }
}
