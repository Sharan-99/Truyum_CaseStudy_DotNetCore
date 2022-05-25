using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Truyum_CaseStudy_DotNetCore.Models;

namespace Truyum_CaseStudy_DotNetCore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TruYumContext context;
        public CustomerController(TruYumContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var category = from i in context.MenuItems.Include(i => i.category)
                           select i;
            return View(category.ToList());
            
        }

       
        public ActionResult Add(int id)
        {
            //var item = context.MenuItems.Find(id);
            var item = context.MenuItems.FirstOrDefault(s => s.Id == id);
            if (item == null)
                return NotFound();
            Cart cart = new Cart();
            cart.MenuItemId = item.Id;
            var c = context.Carts.Add(cart);
            context.SaveChanges();

            return RedirectToAction("Index","Cart");
        }
    }
}
