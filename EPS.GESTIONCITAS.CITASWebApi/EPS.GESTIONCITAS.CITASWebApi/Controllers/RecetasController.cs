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
    public class RecetasController : Controller
    {
        private readonly ILogger<RecetasController> _logger;
        private readonly ICitasServices _citasServices;
        public RecetasController(ILogger<RecetasController> logger, ICitasServices citasServices)
        {
            _logger = logger;
            _citasServices = citasServices;
        }
        [HttpPost(Name = "PostReceta")]
        public IActionResult PostReceta([FromBody] RecetasDTO receta)
        {
            var LstCitas = _citasServices.RegistrarReceta(receta);

            return Ok(LstCitas);
        }
    }
}
