using Microsoft.AspNet.Identity.Owin;
using minamb.Application;
using minamb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static minamb.Application.App;

namespace minamb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UtilizadoresController : MasterController
    {
        // GET: Utilizadores

        private readonly RolesApp _rolesApp;
        private readonly UtilizadoresApp _utilizadoresApp;

        public UtilizadoresController()
        {
            _rolesApp = new RolesApp();
            _utilizadoresApp = new UtilizadoresApp();
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UtilizadoresController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            set
            {
                _signInManager = value;
            }
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        // GET: Admin/Utilizadores
        public ActionResult Index()
        {
            ViewBag.Roles = ToJson(_rolesApp.ListarRoles());
            return View();
        }

        [HttpPost]
        public JsonResult FiltrarUtilizadores(string f)
        {
            var res = _utilizadoresApp.FiltrarUtilizadores(f);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PesquisarUsuarios(string f)
        {
            var res = _utilizadoresApp.FiltrarUtilizadores(f);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult> CriarUtilizadorAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Login, Email = model.Email, Nome = model.Nome };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await UserManager.AddToRolesAsync(user.Id, model.Roles.ToArray());

                    return Json(new AppResultado().Good($"Utilizador {user.Nome} criado com exito."),
                        JsonRequestBehavior.AllowGet);
                }

                return Json(new AppResultado().Bad($"Erro ao tentar criar utilizador {": " + result.Errors.FirstOrDefault()}"),
                        JsonRequestBehavior.AllowGet);
            }

            return Json(new AppResultado().Bad($"Formulario inválido, valide e tente novamente."),
                        JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ActualizaRoles(string idUsuario, List<string> roles)
        {
            return Json(_utilizadoresApp.ModificarRoles(idUsuario, roles));
        }

        [HttpPost]
        public JsonResult ActualizaNome(string idUsuario, string nome, string login)
        {

            return Json(_utilizadoresApp.ModificarNome(idUsuario, nome, login));
        }

        [HttpPost]
        public JsonResult DesactivarUsuario(string idUsuario)
        {
            //_userManager.

            return Json(new { });
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult> ActualizarSenha(string idUsuario, string senha)
        {
            //var utilizador = _utilizadoresApp.UtilizadorById(Guid.Parse(idUsuario));

            var user = await UserManager.FindByIdAsync(idUsuario);

            if (user == null)
            {
                return Json(new AppResultado().Bad("Usuario nao encontrado."));
            }

            string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);

            var result = await UserManager.ResetPasswordAsync(user.Id, code, senha);
            if (result.Succeeded)
            {
                return Json(new AppResultado().Good("Senha actualizada com exito."));
            }

            return Json(new AppResultado().Bad($"Error ao actualizar senha: {result.Errors.FirstOrDefault()}"));
        }
    }
}