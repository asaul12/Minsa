using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static minamb.Application.App;

namespace minamb.Controllers
{
    [Authorize]
    [Erro]
    public class MasterController : Controller
    {
        public void MsgErro(string msg = "Aconteceu um erro ao executar a operação.")
        {
            TempData["Erro"] = msg;
        }

        public void MsgOk(string msg = "Operação executada com exito.")
        {
            TempData["Ok"] = msg;
        }

        public void MsgInfo(string msg)
        {
            TempData["Info"] = msg;
        }

        public void MsgAlert(string msg)
        {
            TempData["Alert"] = msg;
        }

        public string ToJson(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public string ToIgnoreLoop(object o)
        {
            var ret = JsonConvert.SerializeObject(o, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return string.IsNullOrEmpty(ret) ? "[]" : ret;
        }

        public string ToIgnoreLoopDeserialized(object o)
        {
            var ret = JsonConvert.SerializeObject(o, Formatting.Indented, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
            string arr = JsonConvert.DeserializeObject<string>(ret,
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });


            return string.IsNullOrEmpty(arr) ? "[]" : arr;
        }

        public void MostrarResultado(AppResultado resultado)
        {
            if (resultado.Exito)
                MsgOk(resultado.Mensagem);
            else
                MsgErro(resultado.Mensagem);
        }
    }

    public class Erro : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;

            filterContext.ExceptionHandled = true;

            var model = new HandleErrorInfo(filterContext.Exception.InnerException ?? filterContext.Exception, "Controller", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}