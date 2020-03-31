using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoWeiSuperStore.Models;
using NoWeiSuperStore.Models.ViewModels;

namespace NoWeiSuperStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 7;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        //public ViewResult List() => View(repository.Products);
        //public ViewResult List(int productPage = 1)
        //=> View(repository.Products
        //.OrderBy(p => p.ProductID)
        //.Skip((productPage - 1) * PageSize)
        //.Take(PageSize));

        public ViewResult List(string category, int productPage = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
            .Where(p => category == null || p.Category == category)
            .OrderBy(p => p.ProductID)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
        {
            CurrentPage = productPage,
            ItemsPerPage = PageSize,
                TotalItems = category == null ?
                repository.Products.Count() :
                repository.Products.Where(e =>
                e.Category == category).Count()
            },
            CurrentCategory = category
        });

    }
}
