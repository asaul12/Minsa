using minamb.Application.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minamb.Application
{
    public class UtilizadoresApp: App
    {
        public List<UtilizadorDTO> FiltrarUtilizadores(string filtro)
        {
            return db.AspNetUsers.Where(x => x.Nome.Contains(filtro) | x.UserName.Contains(filtro)).Select(x => new UtilizadorDTO
            {
                IdUtilizador = x.Id,
                Nome = x.Nome,
                Login = x.UserName,
                Email = x.Email,
                Roles = x.AspNetRoles.Select(r => r.Name).ToList()
            }).ToList();
        }

        public UtilizadorDTO UtilizadorById(Guid idUtilizador)
        {
            var u = db.AspNetUsers.Find(idUtilizador);

            if (u == null)
            {
                return null;
            }

            var uDTO = new UtilizadorDTO
            {
                IdUtilizador = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Login = u.UserName,
                Roles = u.AspNetRoles.Select(r => r.Name).ToList()
            };

            return uDTO;
        }

        public AppResultado ModificarRoles(string idUsuario, List<string> roles)
        {
            try
            {
                var usuario = db.AspNetUsers.Find(idUsuario);

                if (usuario == null)
                    return new AppResultado().Bad("Usuario inválido");

                usuario.AspNetRoles.Clear();

                foreach (var r in db.AspNetRoles.Where(x => roles.Contains(x.Name)))
                {
                    usuario.AspNetRoles.Add(r);
                }

                db.Entry(usuario).State = EntityState.Modified;

                db.SaveChanges();

                return new AppResultado().Good($"Permissões do utilizador {usuario.Nome} actualizadas com exito.");
            }
            catch
            {
                return new AppResultado().Bad("Erro ao actualizar permissões.");
            }
        }

        public AppResultado ModificarNome(string idUsuario, string nome, string login)
        {
            try
            {
                var usuario = db.AspNetUsers.Find(idUsuario);

                if (usuario == null) return new AppResultado().Bad("Usuario inválido");

                usuario.UserName = login;
                usuario.Nome = nome;
                db.Entry(usuario).State = EntityState.Modified;

                db.SaveChanges();

                return new AppResultado().Good($"Nome do utilizador {usuario.Nome} actualizado com exito.");
            }
            catch
            {
                return new AppResultado().Bad("Erro ao actualizar permissões.");
            }
        }
    }
}
