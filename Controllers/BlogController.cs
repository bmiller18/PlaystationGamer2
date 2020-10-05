using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using PlaystationGamer2.Models;
using Microsoft.EntityFrameworkCore;


namespace PlaystationGamer2.Controllers
{

    public class BlogController : Controller
    {
        private PlaystationGamerContext _context;

        public BlogController(PlaystationGamerContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            IEnumerable<Blog> posts = _context.Blog.ToList<Blog>();
            return View(posts);
        }

        public IActionResult New()
        {
            Blog blogPost = new Blog();

            return View(blogPost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BlogTitle,BlogPost,BlogDate")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(blog);
        }
        public IActionResult Details(int id)
        {
            Blog blogPost = _context.Blog.Find(id);
            return View(blogPost);
        }
        public IActionResult Edit(int id)
        {
            Blog blogPost = _context.Blog.Find(id);
            return View(blogPost);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("BlogTitle,BlogPost,BlogDate,BlogId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Update(blog);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(blog);
        }
        public IActionResult Delete([Bind("BlogId")] int id)
        {
            Blog blogPost = _context.Blog.Find(id);
            _context.Remove(blogPost);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}