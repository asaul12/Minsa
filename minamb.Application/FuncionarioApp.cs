using minamb.Application.Entidades;
using minamb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minamb.Application
{
    public class FuncionarioApp :  App
    {
        public AppResultado CadastrarFuncionario(FuncionarioDTO func)
        {
            try
            {
                var c = new Funcionario
                {
                    IdFuncionario = Guid.NewGuid(),
                    Nome = func.Nome,
                    DataNascimento = func.DataNascimento,
                    IdGenero = func.IdGenero,
                    IdEstadoCivil = func.IdEstadoCivil,
                    IdTipoDocumento = func.IdTipoDocumento,
                    NumDocumento = func.NumDocumento,
                    Morada = func.Morada,
                    IdMunicipio = func.IdMunicipio,
                    NIF = func.NIF,
                    TelefonePrimario = func.TelefonePrimario,
                    TelefoneAlternativo = func.TelefoneAlternativo,
                    Email = func.Email,
                    Profissao = func.Profissao,
                };

                db.Funcionario.Add(c);
                db.SaveChanges();

                return new AppResultado().Good($"Funcionário {c.Nome} cadastrado com exito.");
            }
            catch (Exception e)
            {
                return new AppResultado().Bad("Error ao tentar cadastrar Funcionario, tente novamente.");
            }
        }

        public List<FuncionarioDTO> FiltraFuncionario(string filtro, int? maxRegistos)
        {
            var qry = db.Funcionario.Where(x => x.Nome.ToLower().Contains(filtro.ToLower()) | x.Email.ToLower().Contains(filtro.ToLower()) | x.NumDocumento == filtro | x.TelefonePrimario == filtro);

            if (maxRegistos.HasValue)
                qry = qry.Take(maxRegistos.Value);

            var res = new List<FuncionarioDTO>();

            foreach (var c in qry.ToList())
            {
                var func = new FuncionarioDTO
                {
                    IdFuncionario = c.IdFuncionario,
                    Nome = c.Nome,
                    DataNascimento = c.DataNascimento,
                    DataNascExt = c.DataNascimento.ToString("yyyy-MM-dd"),
                    IdTipoDocumento = c.IdTipoDocumento,
                    TipoDocumentoExt = c.TipoDocumento.Tipo,
                    NumDocumento = c.NumDocumento,
                    IdEstadoCivil = c.IdEstadoCivil,
                    EstadoCivilExt = c.EstadoCivil.Estado,
                    IdGenero = c.IdGenero,
                    GeneroExt = c.Genero.NomeGenero,
                    Morada = c.Morada,
                    IdMunicipio = c.IdMunicipio,
                    MunicipioExt = $"{c.Municipio.Nome}, {c.Municipio.Provincia.Nome}.",
                    Profissao = c.Profissao ?? "",
                    TelefonePrimario = c.TelefonePrimario,
                    TelefoneAlternativo = c.TelefoneAlternativo ?? "",
                    Email = c.Email,
                    NIF = c.NIF,
                    Estado = c.Estado,
                };

                res.Add(func);
            }

            return res;
        }

        public FuncionarioDTO FuncionarioById(Guid idfunc)
        {
            var cli = db.Funcionario.Find(idfunc);

            if (cli == null)
                throw new Exception("O cliente não existe.");

            var perfil = new FuncionarioDTO
            {
                IdFuncionario = cli.IdFuncionario,
                Nome = cli.Nome,
                DataNascimento = cli.DataNascimento,
                DataNascExt = cli.DataNascimento.ToString("yyyy-MM-dd"),
                Morada = $"{cli.Morada}, {cli.Municipio.Nome}, {cli.Municipio.Provincia.Nome}.",
                EstadoCivilExt = cli.EstadoCivil.Estado,
                GeneroExt = cli.Genero.NomeGenero,
                TipoDocumentoExt = cli.TipoDocumento.Tipo,
                IdMunicipio = cli.IdMunicipio,
                IdGenero = cli.IdGenero,
                IdEstadoCivil = cli.IdEstadoCivil,
                IdTipoDocumento = cli.IdTipoDocumento,
                NumDocumento = cli.NumDocumento,
                TelefonePrimario = cli.TelefonePrimario,
                TelefoneAlternativo = cli.TelefoneAlternativo,
                Email = cli.Email,
                Profissao = cli.Profissao,
                NIF = cli.NIF,
            };

            return perfil;
        }

    }
}
