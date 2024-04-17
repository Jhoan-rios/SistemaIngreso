using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SistemaIngreso.Data;
using SistemaIngreso.Models;
using System.Reflection.Metadata;


namespace Historial.Controllers
{
    public class HistorialController : Controller
    {
         public readonly BaseContext _context;
        public HistorialController (BaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>Index(){
            return View(await _context.Historial.ToListAsync());
        }
    }
}