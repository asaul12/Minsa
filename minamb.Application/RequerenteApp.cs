using minamb.Application.Entidades;
using minamb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minamb.Application
{
    public class RequerenteApp :  App
    {
        public AppResultado CadastrarRequerente(RequerenteDTO req)
        {
            var res = new AppResultado();
            try
            {
                var r = new Requerente
                {
                    IdRequerente=Guid.NewGuid(),
                    IdMunicipio=req.IdMunicipio,
                    Nome=req.Nome,
                    PessoaContacto=req.PessoaDeContacto,
                    TelefoneAlternativo=req.TelefoneAlternativo,
                    TelefonePrimario=req.TelefonePrimario,
                    Email=req.Email,
                    ObjetoSocial=req.ObjetoSocial,
                    CNES=req.CNES,
                    IBGE=req.IBGE,
                    UF=req.UF
                };

                db.Requerente.Add(r);
                db.SaveChanges();

                res.Good("Cadastro realizado com sucesso.");

            }
            catch (Exception)
            {

                res.Bad("Erro ao cadastrar requerente.");
            }


            return res;
        }

        public List<RequerenteDTO> ListarRequerentes(string filtro)
        {
            var res = new List<RequerenteDTO>();

            var query = db.Requerente
                .Where(x => x.Nome.ToUpper().Contains(filtro.ToUpper())
            || x.PessoaContacto.ToUpper().Contains(filtro.ToUpper())
            || x.CNES.ToUpper().Contains(filtro.ToUpper())
            || x.IBGE.ToUpper().Contains(filtro.ToUpper())
            || x.UF.ToUpper().Contains(filtro.ToUpper()))
                .AsQueryable();

            res = query.AsEnumerable().Select(x => new RequerenteDTO
            {
                IdRequerente = x.IdRequerente,
                IdMunicipio = x.IdMunicipio,
                MunicipioExt = x.Municipio.Nome,
                Nome = x.Nome,
                PessoaDeContacto = x.PessoaContacto,
                ObjetoSocial = x.ObjetoSocial,
                TelefonePrimario = x.TelefonePrimario,
                TelefoneAlternativo = x.TelefoneAlternativo,
                Endereco = $"{x.Endereco}, {x.Municipio.Nome}, {x.Municipio.Provincia.Nome}.",
                Email = x.Email,
                CNES = x.CNES,
                IBGE = x.IBGE,
                UF = x.UF
            }).ToList();

            return res;
        }
    }
}
