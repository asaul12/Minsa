using minamb.Application.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minamb.Application
{
    public class entidadesEstaticasApp :  App
    {
        public List<GeneroDTO> CargarGeneros()
        {
            return db.Genero.Select(x => new GeneroDTO { IdGenero = x.IdGenero, NomeGenero = x.NomeGenero }).ToList();
        }

        public List<EstadoCivilDTO> CargarEstadosCivis()
        {
            return db.EstadoCivil.Select(x => new EstadoCivilDTO { IdEstadoCivil = x.IdEstadoCivil, Estado = x.Estado }).ToList();
        }

        public List<ProvinciaDTO> CargarProvincias()
        {
            return db.Provincia.Select(x => new ProvinciaDTO
            {
                IdProvincia = x.IdProvincia,
                NomeProvincia = x.Nome,
                Municipios = x.Municipio.Select(m => new MunicipioDTO { IdMunicipio = m.IdMunicipio, NomeMunicipio = m.Nome }).ToList()
            }).ToList();
        }

        public List<TipoDocumentoDTO> CargarTipoDocumento()
        {
            return
                db.TipoDocumento.Select(x => new TipoDocumentoDTO { IdTipoDoc = x.IdTipoDocumento, Tipo = x.Tipo })
                    .ToList();
        }
    }
}
