using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestaoFacil.ConsumirAPI
{
    public class ServicoAPI
    {
        public HttpClient ListServico()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://webapiteste.com.br.asp.hostazul.com.br/api/servico");
            return client;

        }
    }
}
