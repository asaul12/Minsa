using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minamb.Application.Mensagens;
using minamb.Data;

namespace minamb.Application
{
    public class App
    {
        public MinAmbEntities db = new MinAmbEntities();

        public class AppResultado
        {
            public bool Exito { get; set; } = false;

            public string Mensagem { get; set; } = Msg.MSG00001;

            public object Objeto { get; set; }

            public AppResultado Good(string msg)
            {
                this.Exito = true;
                this.Mensagem = msg;

                return this;
            }

            public AppResultado Bad(string msg)
            {
                this.Exito = false;
                this.Mensagem = msg;

                return this;
            }
        }
    }
}
