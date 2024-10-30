using EPS.GESTIONCITAS.CITASDataAccess.Model;
using EPS.GESTIONCITAS.CITASLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EPS.GESTIONCITAS.CITASWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EstadosCitaController : Controller
    {
        private readonly ILogger<EstadosCitaController> _logger;
        private readonly IEstadosCitaServices _estadosCitaServices;
        public EstadosCitaController(ILogger<EstadosCitaController> logger, EstadosCitaServices estadosCitaServices)
        {
            _logger = logger;
            _estadosCitaServices = _estadosCitaServices;
        }
        [HttpGet(Name = "GetEstadosCitas")]
        public async Task<IActionResult> GetAllESTADOSCITAS()
        {
            var LstCitas = await _estadosCitaServices.GetAllESTADOSCITAS();

            return Ok(LstCitas);
        }
        [HttpPost(Name = "PostEstadosCitas")]
        public IActionResult PostEstadosCita([FromBody] ESTADOS_CITAS estadosCitas)
        {
            var LstCitas = _estadosCitaServices.InsEstadosCitas(estadosCitas);

            return Ok(LstCitas);
        }
        [HttpPut(Name = "PutEstadosCita")]
        public IActionResult PutEstadosCita([FromBody] ESTADOS_CITAS estadosCitas)
        {
            var LstCitas = _estadosCitaServices.UpsEstadosCitas(estadosCitas);

            return Ok(LstCitas);
        }
        [HttpDelete(Name = "DelEstadosCita")]
        public IActionResult DelPersonas([FromBody] ESTADOS_CITAS estadosCitas)
        {
            var LstCitas = _estadosCitaServices.DelEstadosCitas(estadosCitas);

            return Ok(LstCitas);
        }
    }
}
