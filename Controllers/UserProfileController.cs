using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaystationGamer2.Models;


namespace PlaystationGamer.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly PlaystationGamerContext _context;
        private UserManager<IdentityUser> _userManager;
        private IHostingEnvironment _webroot;


        public UserProfileController(PlaystationGamerContext context, UserManager<IdentityUser> userManager, IHostingEnvironment webroot)
        {
            _context = context;
            _userManager = userManager;
            _webroot = webroot;
        }

        [Authorize]
        public IActionResult UserInfo()
        {
            string userID = _userManager.GetUserId(User);
            Users profile = _context.Users.FirstOrDefault(p => p.UserAccountId == userID);

            if (profile == null)
            {
                return RedirectToAction("Create");
            }

            return View(profile);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Browse()
        {
            return View(await _context.Users.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Show(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,Email,LastName,FirstName,UserAccountId")] Users users,
            IFormFile FilePhoto)
        {
            if (FilePhoto.Length > 0)
            {
                string photoPath = _webroot.WebRootPath + "\\userPhotos\\";
                var fileName = Path.GetFileName(FilePhoto.FileName);

                using (var stream = System.IO.File.Create(photoPath + fileName))
                {
                    await FilePhoto.CopyToAsync(stream);
                    users.PhotoPath = fileName;
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();

                return RedirectToAction("UserInfo");
            }
            return View(users);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,Email,LastName,FirstName,UserAccountId")] Users users)
        {
            if (id != users.UserId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}