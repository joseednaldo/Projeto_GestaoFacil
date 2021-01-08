using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestaoFacil.ConsumirAPI
{
    public class FuncionarioAPI
    {
        public HttpClient ServicoFuncioanrio()
        {
            //
            var func = new HttpClient();
            func.BaseAddress = new Uri("http://webapiteste.com.br.asp.hostazul.com.br/api/v1/Funcionario");
            return func;

        }
    }
}
