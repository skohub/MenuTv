using System.Collections.Generic;
using System.Linq;
using MenuTv.Entities;

namespace MenuTv.Repositories
{
    public class BeerRepository : IUnitOfWork
    {
        private readonly BeerContext _context;

        public BeerRepository(BeerContext context)
        {
            _context = context;
        }

        public IEnumerable<Beer> FindAll() 
        {
            return _context.Beers
                .OrderBy(x => x.Name)
                .ToList();
        }

        public IEnumerable<Beer> FindAvailable() 
        {
            return _context.Beers
                .Where(x => x.Available)
                .OrderBy(x => x.Name)
                .ToList();
        }

        public Beer Find(int id) 
        {
            return _context.Beers.SingleOrDefault(x => x.Id == id);
        }

        public void Create(Beer beer) 
        {
            _context.Beers.Add(beer);
        }

        public void Update(Beer beer)
        {
            _context.Beers.Update(beer);
        }

        public void Remove(int id)
        {
            var beer = Find(id);
            if (beer == null) return;

            _context.Beers.Remove(beer);
        }

        public bool Exists(int id)
        {
            return _context.Beers.Any(e => e.Id == id);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}