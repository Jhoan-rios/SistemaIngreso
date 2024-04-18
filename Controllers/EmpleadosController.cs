using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SistemaIngreso.Data;
using SistemaIngreso.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;



namespace Empleados.Controllers
{   

    /* [Authorize] */
    public class EmpleadosController : Controller
    {
        public readonly BaseContext _context;
        public EmpleadosController (BaseContext context)
        {
            _context = context;
        }

        /* Select de la conexion de las dos tablas*/

        public IActionResult ObtetnerHistorialDeEmpleado()
        {
            var CookieId = HttpContext.Request.Cookies["Id"];
            var historia = _context.Historial.Where(h => h.Id == Convert.ToInt32(CookieId)).ToList();
            return Ok(historia);
        }

        public IActionResult Index(){
            
            var CookieId = HttpContext.Request.Cookies["Id"];
            var CookieNombre = HttpContext.Request.Cookies["Nombre"];
            ViewBag.CookieNombre = CookieNombre;

            var EmpleadoHorario = _context.Empleados.Include(p => p.Historial).ToList();
            return View(EmpleadoHorario);
        }

        /* public async Task<IActionResult> Index(){

            var CookieNombre = HttpContext.Request.Cookies["Nombre"];
            ViewBag.CookieNombre = CookieNombre;

            var CookieId = HttpContext.Request.Cookies["Id"];

            var EmpleadoHorario = _context.Empleados.Include(p => p.Historial).ToList();
            return View(await _context.Empleados.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(CookieId)));
        } */

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
    }    
}