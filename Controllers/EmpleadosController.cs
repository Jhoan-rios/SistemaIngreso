using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SistemaIngreso.Data;
using SistemaIngreso.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;



namespace Empleados.Controllers
{   

    [Authorize]
    public class EmpleadosController : Controller
    {
        public readonly BaseContext _context;
        public EmpleadosController (BaseContext context)
        {
            _context = context;
        }

        /* Select de la conexion de las dos tablas*/

        public IActionResult ObtetnerHistorialDeEmpleado(int Id)
        {
            var historia = _context.Historial.Where(h => h.Id == Id).ToList();
            return Ok(historia);
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
            e.Contraseña = BCrypt.Net.BCrypt.HashPassword(e.Contraseña);
            _context.Add(e);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        /* [HttpGet("eagerLoading/{id:int}")]
        public async Task<IActionResult> */
    }    
}