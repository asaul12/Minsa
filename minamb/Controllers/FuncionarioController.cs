using minamb.Application;
using minamb.Application.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static minamb.Application.App;

namespace minamb.Controllers
{
    public class FuncionarioController : ManageController
    {
        // GET: Funcionario
        private readonly entidadesEstaticasApp _entidadeEstaticaApp;
        private readonly FuncionarioApp _funcionarioApp;

        public FuncionarioController()
        {
            _entidadeEstaticaApp = new entidadesEstaticasApp();
            _funcionarioApp = new FuncionarioApp();
        }
        public ActionResult Index() 
        {
            ViewBag.Generos = ToJson(_entidadeEstaticaApp.CargarGeneros());
            ViewBag.EstadosCivis = ToJson(_entidadeEstaticaApp.CargarEstadosCivis());
            ViewBag.TipoDocs = ToJson(_entidadeEstaticaApp.CargarTipoDocumento());
            ViewBag.Provincia = ToJson(_entidadeEstaticaApp.CargarProvincias());

            return View();
        }

        public ActionResult Funcionarios()
        {
            ViewBag.Generos = ToJson(_entidadeEstaticaApp.CargarGeneros());
            ViewBag.EstadosCivis = ToJson(_entidadeEstaticaApp.CargarEstadosCivis());
            ViewBag.TipoDocs = ToJson(_entidadeEstaticaApp.CargarTipoDocumento());
            ViewBag.Provincia = ToJson(_entidadeEstaticaApp.CargarProvincias());

            return View();
        }

        [HttpPost]
        public JsonResult CriarFuncionario(FuncionarioDTO funcionario)
        {
            if (ModelState.IsValid)
            {
                return Json(_funcionarioApp.CadastrarFuncionario(funcionario));
            }

            return Json(new AppResultado().Bad($"Erro ao tentar criar Funcionario {": " + ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault().ErrorMessage}"),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult FiltrarFuncionario(string filtro)
        {
            var res = _funcionarioApp.FiltraFuncionario(filtro, 100);

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PerfilFuncionario(Guid id)
        {
            ViewBag.Cliente = ToJson(_funcionarioApp.FuncionarioById(id));
            return View();
        }
    }
}