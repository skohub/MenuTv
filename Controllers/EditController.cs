using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MenuTv.Entities;
using MenuTv.Repositories;

namespace MenuTv.Controllers
{
    public class EditController : Controller
    {
        private readonly BeerRepository _repo;

        public EditController(BeerRepository repo)
        {
            _repo = repo;
        }

        // GET: Edit
        public  IActionResult Index()
        {
            return View(_repo.FindAll());
        }

        // GET: Edit/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = _repo.Find(id.Value);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // GET: Edit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Edit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Comment,Price")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                _repo.Create(beer);
                _repo.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(beer);
        }

        // GET: Edit/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = _repo.Find(id.Value);
            if (beer == null)
            {
                return NotFound();
            }
            return View(beer);
        }

        // POST: Edit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Comment,Price,Available")] Beer beer)
        {
            if (id != beer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(beer);
                    _repo.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_repo.Exists(beer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beer);
        }

        // GET: Edit/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = _repo.Find(id.Value);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // POST: Edit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Remove(id);
            _repo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
