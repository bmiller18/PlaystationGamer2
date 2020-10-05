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
    public class ConsoleController : Controller
    {
        private readonly PlaystationGamerContext _context;

        public ConsoleController(PlaystationGamerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Console.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var console = await _context.Console
                .FirstOrDefaultAsync(m => m.ConsoleId == id);
            if (console == null)
            {
                return NotFound();
            }

            return View(console);
        }
    }
}
