using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minamb.Application.Entidades
{
    public class FuncionarioDTO
    {
        private static DateTime _dataNascimento;
 
        public Guid IdFuncionario { get; set; }
        
        [MaxLength(100,ErrorMessage = "O campo {0} tem um limite de {1} caracteres")]
        [Required (ErrorMessage = "O campo {0} é obrigatorio.")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        //public DateTime DataNascimento
        //{
        //    get => _dataNascimento;
        //    set => _dataNascimento = value;
        //}

        //public string DataNascExt { get; set; } = _dataNascimento.ToString("dd-MM-yyyy");

        [Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        public DateTime DataNascimento { get; set; }
        public string DataNascExt { get; set; }

        [Display(Name = "Profissão")]
        [MaxLength(50, ErrorMessage = "O campo {0} tem um limite de {1} caracteres")]
        public string Profissao { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        [Display(Name = "Tipo de Documento")]
        public int IdTipoDocumento { get; set; }
        public string TipoDocumentoExt { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        [Display(Name = "Número de Documento")]
        [MaxLength(25, ErrorMessage = "O campo {0} tem um limite de {1} caracteres")]
        public string NumDocumento { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        //[MaxLength(250, ErrorMessage = "O campo {0} tem um limite de {1} caracteres")]
        public string Morada { get; set; } = "";

        //[Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        //[Display(Name = "Municipio")]
        public int IdMunicipio { get; set; } = 1;
        public string MunicipioExt { get; set; }


        //[Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        //[Display(Name = "Estado Civil")]
        public int IdEstadoCivil { get; set; } = 4;
        public string EstadoCivilExt { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        //[Display(Name = "Genero")]
        public int IdGenero { get; set; } = 1;

        public string GeneroExt { get; set; }

        [MaxLength(9, ErrorMessage = "O campo {0} tem um limite de {1} caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        [Display(Name = "Telefone Primario")]
        public string TelefonePrimario { get; set; }

        [MaxLength(9, ErrorMessage = "O campo {0} tem um limite de {1} caracteres")]
        [Display(Name = "Telefone Alternativo")]
        public string TelefoneAlternativo { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} tem um limite de {1} caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        //[MaxLength(100, ErrorMessage = "O campo {0} tem um limite de {1} caracteres")]
        public string NIF { get; set; } = "";

        public bool Estado { get; set; }

    }
}
