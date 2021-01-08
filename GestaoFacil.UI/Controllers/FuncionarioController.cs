using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GestaoFacil.ConsumirAPI;
using GestaoFacil.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestaoFacil.Controllers
{
    public class FuncionarioController : Controller
    {

        FuncionarioAPI api = new FuncionarioAPI();


        public async Task<IActionResult> Teste()
        {
            

            return View();


        }
        // GET: FuncionarioController
        public async Task<ActionResult> Index()
        {
            List<FuncionarioData> funcioanario = new List<FuncionarioData>();
            var resultado = RetornaDadosApi();
            if (resultado.Result.IsSuccessStatusCode)
            {
                var result = resultado.Result.Content.ReadAsStringAsync().Result;
                funcioanario = JsonConvert.DeserializeObject<List<FuncionarioData>>(result);
            }
            return View(funcioanario);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FuncionarioData funcionario)
        {

            HttpClient client = api.ServicoFuncioanrio();
            StringContent contentString = SerializaJsonToObject(funcionario);
            var postBack = client.PostAsync("Funcionario", contentString);

            var resultado = postBack.Result;
            if (resultado.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View();
        }

        private static StringContent SerializaJsonToObject(FuncionarioData funcionario)
        {
            var jsonContent = JsonConvert.SerializeObject(funcionario);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");
            // contentString.Headers.Add("Session-Token", session_token);
            return contentString;
        }

        // GET: FuncionarioController/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {
            FuncionarioData funcionario = new FuncionarioData();
            HttpClient client = api.ServicoFuncioanrio();
            HttpResponseMessage res = await client.GetAsync($"Funcionario/{Id}");
            if (res.IsSuccessStatusCode)
                funcionario = JsonConvert.DeserializeObject<FuncionarioData>(res.Content.ReadAsStringAsync().Result);
        
            return View(funcionario);
        }

        // POST: FuncionarioController/Edit/5
        [HttpPost]
        public ActionResult Edit(FuncionarioData funcionario)
        {


            HttpClient client = api.ServicoFuncioanrio();
            try
            {

                var jsonContent = JsonConvert.SerializeObject(funcionario);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new
                MediaTypeHeaderValue("application/json");


                var postBack = client.PutAsync($"Funcionario/{funcionario.FuncionarioId}", contentString);

                var resultado = postBack.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }


        //get
        public async Task<IActionResult> Details(int Id)
        {
        //    FuncionarioData funcioanrio = new FuncionarioData();
        //    var resultado = RetornaDadosApi(Id.ToString());
        //    if (resultado.Result.IsSuccessStatusCode)
        //    {
        //        funcioanrio = JsonConvert.DeserializeObject<FuncionarioData>(resultado.Result.Content.ReadAsStringAsync().Result);
        //    }

        //    return View(funcioanrio);

            FuncionarioData Servico = new FuncionarioData();
            HttpClient client = api.ServicoFuncioanrio();
            HttpResponseMessage res = await client.GetAsync($"Funcionario/{Id}");

                    if (res.IsSuccessStatusCode)
                    {
                    var resutlado = res.Content.ReadAsStringAsync().Result;
                    Servico = JsonConvert.DeserializeObject<FuncionarioData>(resutlado);
                    }

            return View(Servico);


}

        // GET: FuncionarioController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                HttpClient client = api.ServicoFuncioanrio();
                HttpResponseMessage res = await client.DeleteAsync($"Funcionario/{id}");
                //var resultado = RetornaDadosApi(id);
                return RedirectToAction("index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST: FuncionarioController/Edit/5
        [HttpPost]
        public ActionResult Editar(FuncionarioData funcionario)
        {


            HttpClient client = api.ServicoFuncioanrio();
            try
            {

                var jsonContent = JsonConvert.SerializeObject(funcionario);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new
                MediaTypeHeaderValue("application/json");


                var postBack = client.PutAsync($"Funcionario/{funcionario.FuncionarioId}", contentString);

                var resultado = postBack.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }



        private async Task<HttpResponseMessage> RetornaDadosApi(int id = 0 )
        {

            try
            {
                HttpClient client = api.ServicoFuncioanrio();

                if (id == 0 || id == null)
                {
                    HttpResponseMessage res = await client.GetAsync("Funcionario");
                    return res;
                }else
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
