using Microsoft.AspNetCore.Mvc;
using SistemaIngreso.Data;
using Microsoft.EntityFrameworkCore;
using SistemaIngreso.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;




namespace Login.Controllers{

    
    public class LoginController:Controller{

        public readonly BaseContext _context;
        public LoginController (BaseContext context)
        {
            _context = context;
        }
        public IActionResult Index(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Correo, string Contraseña){
            var empleado = _context.Empleados.FirstOrDefault(e => e.Correo == Correo);

            if (empleado != null && BCrypt.Net.BCrypt.Verify(Contraseña, empleado.Contraseña)){
                
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, empleado.Nombre),
                    new Claim("Correo", empleado.Correo)
                };

                var claimsIndentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIndentity));

                
                return RedirectToAction("Index", "Empleados");
            }
            else{
                return View();
            }
        }

        public async Task<IActionResult> Salir(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

    }
}