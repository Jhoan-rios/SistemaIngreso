using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SistemaIngreso.Data;
using SistemaIngreso.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;
using Historial.Controllers;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;



namespace Empleados.Controllers
{   

    //[Authorize] 
    public class EmpleadosController : Controller
    {
        public readonly BaseContext _context;
        public EmpleadosController (BaseContext context)
        {
            _context = context;
        }

        /* Select de la conexion de las dos tablas*/

        public IActionResult ObtetnerHistorialDeEmpleado(int? Id)
        {
            var historia = _context.Historial.Where(h => h.Id == Id).ToList();
            return Ok(historia);
        }

        public async Task<IActionResult> Index(){
            var CookieId = HttpContext.Request.Cookies["Id"];
            var CookieNombre = HttpContext.Request.Cookies["Nombre"];
            ViewBag.CookieNombre = CookieNombre;


            var EmpleadoHorario = _context.Empleados.Include(p => p.Historial).ToList();
            
            /* A partir de aqui esta el cambio de boton */
            var salida = _context.Historial.OrderByDescending(s => s.HoraSalida).FirstOrDefault();

            if(salida != null && salida.HoraSalida == null)
            {
                ViewData["BtnDisabled"] = true; 
            }
            else
            {
                ViewData["BtnDisabled"] = false;
            }
            /* Hasta aqui es el cambio de boton */

             var query = _context.Historial.AsQueryable();
             query = query.Where(e => e.IdEmpleado == int.Parse(CookieId)); 
            ViewData["userdata"] = query.ToList();


            return View(EmpleadoHorario);
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

        
        public IActionResult Entrada(){
            var CookieId = HttpContext.Request.Cookies["Id"];

            var HoraEntrada = new Historia{
                HoraEntrada = DateTime.Now,
                IdEmpleado = Int32.Parse(CookieId),
            };

            _context.Historial.Add(HoraEntrada);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
           


    

        
    }    
}