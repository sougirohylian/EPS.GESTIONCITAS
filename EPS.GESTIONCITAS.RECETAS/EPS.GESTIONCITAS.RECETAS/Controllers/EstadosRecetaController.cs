using EPS.GESTIONCITAS.RECETASLogic.Services;
using Microsoft.AspNetCore.Mvc;
using EPS.GESTIONCITAS.RECETASDataAccess.Model;
using Microsoft.AspNetCore.Authorization;
using EPS.GESTIONCITAS.RECETAS.Controllers;

namespace EPS.GESTIONCITAS.RECETASWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EstadosRecetaController : Controller
    {
        private readonly ILogger<EstadosRecetaController> _logger;
        private readonly IEstadosRecetaServices _estadosRecetasServices;
        public EstadosRecetaController(ILogger<EstadosRecetaController> logger, IEstadosRecetaServices estadosRecetasServices)
        {
            _logger = logger;
            _estadosRecetasServices = estadosRecetasServices;
        }
        [HttpGet(Name = "GetEstadosRecetas")]
        public async Task<IActionResult> GetAllESTADOSRECETAS()
        {
            var LstCitas = await _estadosRecetasServices.GetAllESTADOSRECETAS();

            return Ok(LstCitas);
        }
        [HttpPost(Name = "PostEstadosRecetas")]
        public IActionResult PostEstadosRecetas([FromBody] ESTADOS_RECETAS estadosRecetas)
        {
            var LstRecetas = _estadosRecetasServices.InsEstadosRecetas(estadosRecetas);

            return Ok(LstRecetas);
        }
        [HttpPut(Name = "PutEstadosRecetas")]
        public IActionResult PutEstadosRecetas([FromBody] ESTADOS_RECETAS estadosRecetas)
        {
            var LstPersonas = _estadosRecetasServices.UpsEstadosRecetas(estadosRecetas);

            return Ok(LstPersonas);
        }
        [HttpDelete(Name = "DelEstadosRecetas")]
        public IActionResult DelEstadosPersonas([FromBody] ESTADOS_RECETAS estadosRecetas)
        {
            var LstPersonas = _estadosRecetasServices.DelEstadosRecetas(estadosRecetas);

            return Ok(LstPersonas);
        }
    }
}
