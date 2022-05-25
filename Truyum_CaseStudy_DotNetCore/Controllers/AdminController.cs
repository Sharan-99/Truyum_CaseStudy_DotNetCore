using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Truyum_CaseStudy_DotNetCore.Models;

namespace Truyum_CaseStudy_DotNetCore.Controllers
{
    public class AdminController : Controller
    {
        private readonly TruYumContext context;
        public AdminController(TruYumContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            //var context = new TruYumContext();
            //var item = from items in context.MenuItems
              //         select items;
            var category = from i in context.MenuItems.Include(i => i.category)
                           select i;
            return View(category.ToList());
        }

        public IActionResult Create()
        {
            List<Category> categoryList = new List<Category>();
            categoryList = (from category in context.Categories
                            select category).ToList();
            categoryList.Insert(0, new Category { Id = 0, Name = "select" });
            ViewBag.categories = categoryList;
            return View();
        } 

        [HttpPost]
        public IActionResult Create(MenuItem menu)
        {
            if (!ModelState.IsValid)
                return View(menu);
            context.MenuItems.Add(menu);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            List<Category> categoryList = new List<Category>();
            categoryList = (from category in context.Categories
                            select category).ToList();
            categoryList.Insert(0, new Category { Id = 0, Name = "select" });
            ViewBag.categories = categoryList;
            var menuItem = context.MenuItems.Find(id);
            if (menuItem == null) return NotFound();
            return View(menuItem);
        }



        [HttpPost]
        public IActionResult Edit(MenuItem menuItem)
        {
            if (!ModelState.IsValid)
                return View(menuItem);
            context.Attach(menuItem);
            context.Entry(menuItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
