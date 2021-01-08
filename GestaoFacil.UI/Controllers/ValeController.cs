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
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace GestaoFacil.Controllers
{
    public class ValeController : Controller
    {
        ValeAPI _api = new ValeAPI();
        public async Task<IActionResult> Index()
        {

            List<ValeData> Vales = new List<ValeData>();
            HttpClient client = _api.ListVale();
            HttpResponseMessage result = await client.GetAsync("Vale");
            if (result.IsSuccessStatusCode) 
            {
                var resultado = result.Content.ReadAsStringAsync().Result;
                Vales = JsonConvert.DeserializeObject<List<ValeData>>(resultado);
            }

            return View(Vales);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            ValeData Vale = new ValeData();
            HttpClient client = _api.ListVale();
            HttpResponseMessage res = await client.GetAsync($"Vale/{Id}");

            if (res.IsSuccessStatusCode)
            {
                var resutlado = res.Content.ReadAsStringAsync().Result;
                Vale = JsonConvert.DeserializeObject<ValeData>(resutlado);
            }

            return View(Vale);
        }


        [HttpPost]
        public ActionResult Edit(ValeData vale)
        {


            HttpClient client = _api.ListVale();
            //http post

            var jsonContent = JsonConvert.SerializeObject(vale);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");
            // contentString.Headers.Add("Session-Token", session_token);


            var postBack = client.PutAsync($"Vale/{vale.ValeId}", contentString);

            var resultado = postBack.Result;
            if (resultado.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View();
        }



        public ActionResult Create()
        {


            List<FuncionarioData> funcioanario = new List<FuncionarioData>();
            var resultado = RetornaDadosApi();
            if (resultado.Result.IsSuccessStatusCode)
            {
                var result = resultado.Result.Content.ReadAsStringAsync().Result;
                funcioanario = JsonConvert.DeserializeObject<List<FuncionarioData>>(result);
            }

            ViewBag.TiposFichero = new SelectList(
              funcioanario,
             "FuncionarioId",
             "Nome");



            return View();
        }

        [HttpPost]
        public ActionResult Create(ValeData vale)
        {


            HttpClient client = _api.ListVale();
            //http post

           var jsonContent = JsonConvert.SerializeObject(vale);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");



            var postBack = client.PostAsync("Vale", contentString);

            var resultado = postBack.Result;
            if (resultado.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View();
        }

        private async Task<HttpResponseMessage> RetornaDadosApi(int id = 0)
        {

            try
            {
                FuncionarioAPI api = new FuncionarioAPI();
                HttpClient client = api.ServicoFuncioanrio();

                if (id == 0 || id == null)
                {
                    HttpResponseMessage res = await client.GetAsync("Funcionario");
                    return res;
                }
                else
                {
                    HttpResponseMessage res = await client.GetAsync($"Funcionario/{id}");
                    return res;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
