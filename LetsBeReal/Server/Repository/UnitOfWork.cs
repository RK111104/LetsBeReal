using LetsBeReal.Server.Data;
using LetsBeReal.Server.IRepository;
using LetsBeReal.Server.Models;
using LetsBeReal.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace LetsBeReal.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Genre> _genres;
        private IGenericRepository<Product> _products;
        private IGenericRepository<Reviews> _reviewss;
        private IGenericRepository<Update> _updates;
        private IGenericRepository<UserInterest> _userinterests;
        private IGenericRepository<Games> _gamess;
        private IGenericRepository<UserRank> _userranks;
        private IGenericRepository<User> _users;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Genre> Genres
            => _genres ??= new GenericRepository<Genre>(_context);
        public IGenericRepository<Product> Products
            => _products ??= new GenericRepository<Product>(_context);
        public IGenericRepository<Reviews> Reviewss
            => _reviewss ??= new GenericRepository<Reviews>(_context);
        public IGenericRepository<Update> Updates
            => _updates ??= new GenericRepository<Update>(_context);
        public IGenericRepository<UserInterest> UserInterests
            => _userinterests ??= new GenericRepository<UserInterest>(_context);

        public IGenericRepository<Games> Gamess
            => _gamess ??= new GenericRepository<Games>(_context);
        public IGenericRepository<UserRank> UserRanks
            => _userranks ??= new GenericRepository<UserRank>(_context);

        public IGenericRepository<User> Users
            => _users ??= new GenericRepository<User>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
 
            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);


            await _context.SaveChangesAsync();
        }
    }
}

