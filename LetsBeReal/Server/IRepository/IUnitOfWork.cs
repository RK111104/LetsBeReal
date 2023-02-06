using LetsBeReal.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LetsBeReal.Server.IRepository
{
  
        public interface IUnitOfWork : IDisposable
        {
            Task Save(HttpContext httpContext);
            IGenericRepository<Games> Gamess { get; }
            IGenericRepository<Genre> Genres { get; }
            IGenericRepository<Reviews> Reviewss { get; }
            IGenericRepository<Product> Products { get; }
            IGenericRepository<UserInterest> UserInterests { get; }
            IGenericRepository<UserRank> UserRanks { get; }
            IGenericRepository<Update> Updates { get; }
            IGenericRepository<User> Users { get; }
        }
}


