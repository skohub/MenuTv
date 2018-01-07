using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MenuTv.Entities;
using MenuTv.Repositories;

namespace MenuTv.Controllers
{
    public class MenuController : Controller
    {
        private readonly BeerRepository _repo;

        public MenuController(BeerRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var beers = _repo.FindAvailable();
            if (beers.Count() <= 10) 
            {
                return View("ShortView", beers);
            } 
            else 
            {
                return View("LongView", beers);
            }
        }
    }
}