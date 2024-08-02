using Microsoft.AspNetCore.Mvc;
using PeliculaApp2.Models;
using PeliculaApp2.Services;
namespace PeliculaApp2.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly PeliculaService _peliculaService;
        public PeliculasController(PeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }
        public IActionResult Index()
        {
            var peliculas = _peliculaService.GetPeliculas();
            return View(peliculas);
        }
        //Crear Pelicula

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                _peliculaService.InsertPelicula(pelicula);
                return RedirectToAction(nameof(Index));
            }
            return View(pelicula);
        }
    }
}
