using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Entitiy;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products.Where(i => i.IsHome && i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name =i.Name,
                Description = i.Description.Length>50?i.Description.Substring(0,47)+"...":i.Description,
                Price =i.Price,
                Stock =i.Stock,
                //Image = i.Image
                CategoryId =i.CategoryId


            }).ToList();

            return View(urunler);
        }
        public ActionResult Details(int? id)
        {
            return View(_context.Products.Where(i => i.Id== id).FirstOrDefault());
        }
        public ActionResult List(int? id) 
        {
            var urunler = _context.Products.Where(i => i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                //Image = i.Image==null?"1.jpg":i.Image ,          //OLMAYAN RESİMLERE 1.JPG ATANIR
                CategoryId = i.CategoryId


            }).AsQueryable(); // filtreleme ekleniyor

            if(id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id); //list sayfasının  solundaki kategorilere tıkladığında filtreli gelmesini sağlıyor
            }

            return View(urunler.ToList());
        }
        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}