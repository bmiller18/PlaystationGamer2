using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal;
using Microsoft.EntityFrameworkCore;
using PlaystationGamer2.Models;

namespace PlaystationGamer2.Controllers
{
    public class ControllersController : Controller
    {
        private readonly PlaystationGamerContext _context;

        public ControllersController(PlaystationGamerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Controllers.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controllers = await _context.Controllers
                .FirstOrDefaultAsync(m => m.ControllerId == id);
            if (controllers == null)
            {
                return NotFound();
            }

            return View(controllers);
        }
    }
}
