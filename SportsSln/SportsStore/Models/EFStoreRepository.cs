using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;
        public EFStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        /*The Products property in the context class returns a DbSet<Product> object, which implements the IQueryable<T> interface*/
        public IQueryable<Product> Products => context.Products;
    }
}
