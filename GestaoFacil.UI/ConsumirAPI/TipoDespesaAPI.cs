using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestaoFacil.ConsumirAPI
{
    public class TipoDespesaAPI
    {
        public HttpClient ServicoTipoDespesa()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://webapiteste.com.br.asp.hostazul.com.br/api/TipoDespesa");
            return client;

        }
    }
}
