using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
   /* A class that depends on the IProductRepository interface can obtain Product objects without needing to know the details of
how they are stored or how the implementation class will deliver them.*/
    public interface IStoreRepository
    {
        /*        This interface uses IQueryable<T> to allow a caller to obtain a sequence of Product objects.The IQueryable<T> interface is
        derived from the more familiar IEnumerable<T> interface and represents a collection of objects that can be queried, such as those
        managed by a database.*/
        IQueryable<Product> Products { get; }
    }
}
