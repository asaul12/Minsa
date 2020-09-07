using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minamb.Application.Entidades
{
    public class RequerenteDTO
    {
        public Guid IdRequerente { get; set; }
        public string Nome { get; set; }
        public string PessoaDeContacto { get; set; }
        public string TelefonePrimario { get; set; }
        public string TelefoneAlternativo { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public int IdMunicipio { get; set; }
        public string MunicipioExt { get; set; }
        public string ObjetoSocial { get; set; }
        public string CNES { get; set; }
        public string IBGE { get; set; }
        public string UF { get; set; }
    }
}
