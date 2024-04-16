using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SistemaIngreso.Data;
using SistemaIngreso.Models;
using BCrypt.Net;

namespace Empleados.Controllers
{
    public class EmpleadosController : Controller
    {
        public readonly BaseContext _context;
        public EmpleadosController (BaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>Index(){
            return View(await _context.Empleados.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id){
            return View(await _context.Empleados.FirstOrDefaultAsync(e => e.Id == id));
        }
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        public IActionResult Create(Empleado e){
            _context.Add(e);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }    
}