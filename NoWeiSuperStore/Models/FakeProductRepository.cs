using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoWeiSuperStore.Models
{
    public class FakeProductRepository /*: IProductRepository*/
    {
        public IQueryable<Product> Products => new List<Product> {
        new Product { Name = "Wei's Signature Weaponized Football", Price = 25 },
        new Product { Name = "Mithril Rocket Propelled Surf board", Price = 179 },
        new Product { Name = "FeatherLite Bounding Running shoes", Price = 95 }
        }.AsQueryable<Product>();
    }
}
