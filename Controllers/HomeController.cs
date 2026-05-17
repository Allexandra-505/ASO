using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<Sarcina> sarcini = new List<Sarcina>
        {
            new Sarcina { Text = "Să îmi prezint tema la facultate", Finalizata = false },
            new Sarcina { Text = "Să învăț elementele de bază din ASP.NET", Finalizata = true }
        };

        public IActionResult Index()
        {
            ViewBag.Total = sarcini.Count;
            ViewBag.Rezolvate = sarcini.Count(s => s.Finalizata);
            return View(sarcini);
        }

        [HttpPost]
        public IActionResult Adauga(string sarcinaNouа)
        {
            if (!string.IsNullOrEmpty(sarcinaNouа))
                sarcini.Add(new Sarcina { Text = sarcinaNouа });
            return RedirectToAction("Index");
        }

        public IActionResult Bifeaza(int index)
        {
            if (index >= 0 && index < sarcini.Count)
                sarcini[index].Finalizata = !sarcini[index].Finalizata;
            return RedirectToAction("Index");
        }

        public IActionResult Sterge(int index)
        {
            if (index >= 0 && index < sarcini.Count)
                sarcini.RemoveAt(index);
            return RedirectToAction("Index");
        }
    }
}