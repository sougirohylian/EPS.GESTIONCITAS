﻿using EPS.GESTIONCITAS.RECETASWebApi.DTO;
using EPS.GESTIONCITAS.RECETASWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EPS.GESTIONCITAS.RECETASWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService authService;
        public LoginController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost]
        public ActionResult Token(UserLogin credenciales)
        {
            if (authService.ValidateLogin(credenciales.Username, credenciales.Password))
            {
                var fechaActual = DateTime.UtcNow;
                var validez = TimeSpan.FromHours(5);
                var fechaExpiracion = fechaActual.Add(validez);

                var token = authService.GenerateToken(fechaActual, credenciales.Username, validez);
                return Ok(new
                {
                    Token = token,
                    ExpireAt = fechaExpiracion
                });
            }
            return StatusCode(401);
        }
    }
}
