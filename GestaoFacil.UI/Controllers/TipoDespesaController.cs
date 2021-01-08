using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GestaoFacil.ConsumirAPI;
using GestaoFacil.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestaoFacil.Controllers
{
    public class TipoDespesaController : Controller
    {

        TipoDespesaAPI api = new TipoDespesaAPI();

        // GET: TipoDespesaController
        public ActionResult Index()
        {
            List<TipoDepesaData> funcioanario = new List<TipoDepesaData> ();
            var resultado = RetornaDadosApi();
            if (resultado.Result.IsSuccessStatusCode)
            {
                var result = resultado.Result.Content.ReadAsStringAsync().Result;
                funcioanario = JsonConvert.DeserializeObject<List<TipoDepesaData>>(result);
            }
            return View(funcioanario);
        }

        // GET: TipoDespesaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoDespesaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDespesaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDespesaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoDespesaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDespesaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoDespesaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        private async Task<HttpResponseMessage> RetornaDadosApi(int id = 0)
        {

            try
            {
                HttpClient client = api.ServicoTipoDespesa();

                if (id == 0 || id == null)
                {
                    HttpResponseMessage res = await client.GetAsync("TipoDespesa");
                    return res;
                }
                else
                {
                    HttpResponseMessage res = await client.GetAsync($"TipoDespesa/{id}");
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
