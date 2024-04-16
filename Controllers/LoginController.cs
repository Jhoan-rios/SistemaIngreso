using Microsoft.AspNetCore.Mvc;
using SistemaIngreso.Data;
using Microsoft.EntityFrameworkCore;
using SistemaIngreso.Models;
using BCrypt.Net;

namespace Login.Controllers{
    public class LoginController:Controller{
        public IActionResult Index(){
            return View();
        }

    }
}