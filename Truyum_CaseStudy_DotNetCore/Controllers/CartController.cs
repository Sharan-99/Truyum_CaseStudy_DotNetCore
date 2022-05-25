using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Truyum_CaseStudy_DotNetCore.Models;
namespace Truyum_CaseStudy_DotNetCore.Controllers
{
    public class CartController : Controller
    {
        private readonly TruYumContext context;
        public CartController(TruYumContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var cartItems = from i in context.Carts.Include(m => m.MenuItem)
                            select i;
            return View(cartItems.ToList());
        }

        public IActionResult Remove(int id)
        {
            var cartItem = context.Carts.Find(id);
            if (cartItem == null) return NotFound();
            context.Carts.Remove(cartItem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
