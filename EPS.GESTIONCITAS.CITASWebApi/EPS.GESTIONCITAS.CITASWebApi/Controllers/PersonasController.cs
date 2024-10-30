using EPS.GESTIONCITAS.CITASDataAccess.Model;
using EPS.GESTIONCITAS.CITASLogic.DTO;
using EPS.GESTIONCITAS.CITASLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EPS.GESTIONCITAS.CITASWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PersonasController : Controller
    {
        private readonly ILogger<PersonasController> _logger;
        private readonly ICitasServices _citasServices;
        public PersonasController(ILogger<PersonasController> logger, ICitasServices citasServices)
        {
            _logger = logger;
            _citasServices = citasServices;
        }
        [HttpGet(Name = "GetPersonas")]
        public async Task<IActionResult> GetAllPersonas()
        {
            var LstPersonas = await _citasServices.ObtenerPersonas();

            return Ok(LstPersonas);
        }
    }
}
