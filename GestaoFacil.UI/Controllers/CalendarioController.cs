using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFacil.Controllers
{
    public class CalendarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
