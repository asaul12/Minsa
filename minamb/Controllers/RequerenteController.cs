using minamb.Application;
using minamb.Application.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace minamb.Controllers
{
    public class RequerenteController : MasterController
    {
        // GET: Requerente
        private readonly RequerenteApp _requerenteApp;
        private readonly entidadesEstaticasApp _entidadeEstaticaApp;

        public RequerenteController()
        {
            _requerenteApp = new RequerenteApp();
            _entidadeEstaticaApp = new entidadesEstaticasApp();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Requerentes()
        {
            ViewBag.Generos = ToJson(_entidadeEstaticaApp.CargarGeneros());
            ViewBag.EstadosCivis = ToJson(_entidadeEstaticaApp.CargarEstadosCivis());
            ViewBag.TipoDocs = ToJson(_entidadeEstaticaApp.CargarTipoDocumento());
            ViewBag.Provincia = ToJson(_entidadeEstaticaApp.CargarProvincias());

            return View();
        }

        [HttpPost]
        public JsonResult CadastrarRequerente(RequerenteDTO req)
        {
            return Json(_requerenteApp.CadastrarRequerente(req), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PesquisarRequerentes(string filtro)
        {
            return Json(_requerenteApp.ListarRequerentes(filtro), JsonRequestBehavior.AllowGet);
        }
    }
}