using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GestaoFacil.ConsumirAPI;
using GestaoFacil.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestaoFacil.Controllers
{
    public class ServicoController : Controller
    {

        ServicoAPI _api = new ServicoAPI();


        public async Task<IActionResult> Index()
        {
            List<ServicoData> Servico = new List<ServicoData>();
            HttpClient client = _api.ListServico();
            HttpResponseMessage res = await client.GetAsync("Servico");

            if (res.IsSuccessStatusCode)
            {
                var resutlado = res.Content.ReadAsStringAsync().Result;
                Servico = JsonConvert.DeserializeObject<List<ServicoData>>(resutlado);
            }

            return View(Servico);


        }

        public async Task<IActionResult> Details(int Id)
        {
            ServicoData Servico = new ServicoData();
            HttpClient client = _api.ListServico();
            HttpResponseMessage res = await client.GetAsync($"Servico/{Id}");

            if (res.IsSuccessStatusCode)
            {
                var resutlado = res.Content.ReadAsStringAsync().Result;
                Servico = JsonConvert.DeserializeObject<ServicoData>(resutlado);
            }

            return View(Servico);

        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ServicoData servico)
        {


            HttpClient client = _api.ListServico();
            //http post

            var jsonContent = JsonConvert.SerializeObject(servico);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");
            // contentString.Headers.Add("Session-Token", session_token);


            var postBack = client.PostAsync("Servico", contentString);

            var resultado = postBack.Result;
            if (resultado.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int Id)
        {
            ServicoData Servico = new ServicoData();
            HttpClient client = _api.ListServico();
            HttpResponseMessage res = await client.GetAsync($"Servico/{Id}");

            if (res.IsSuccessStatusCode)
            {
                var resutlado = res.Content.ReadAsStringAsync().Result;
                Servico = JsonConvert.DeserializeObject<ServicoData>(resutlado);
            }

            return View(Servico);
        }


        [HttpPost]
        public ActionResult Edit(ServicoData servico)
        {


            HttpClient client = _api.ListServico();
            //http post

            var jsonContent = JsonConvert.SerializeObject(servico);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");
            // contentString.Headers.Add("Session-Token", session_token);
          

            var postBack = client.PutAsync($"Servico/{servico.ServicoId}", contentString);

            var resultado = postBack.Result;
            if (resultado.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View();
        }


        public async Task<IActionResult> Delete(int Id)
        {
            List<ServicoData> Servico = new List<ServicoData>();
            HttpClient client = _api.ListServico();
            HttpResponseMessage res = await client.DeleteAsync($"Servico/{Id}");

            return RedirectToAction("index");

        }

    }
}
