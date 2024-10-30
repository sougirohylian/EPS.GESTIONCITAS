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
    public class CitasEstadosController : Controller
    {
        private readonly ILogger<CitasEstadosController> _logger;
        private readonly ICitasServices _citasServices;
        public CitasEstadosController(ILogger<CitasEstadosController> logger, ICitasServices citasServices)
        {
            _logger = logger;
            _citasServices = citasServices;
        }
        [HttpPost(Name = "PostCitasEstados/{ID_ESTADO}")]
        public IActionResult GetCitasEstados([FromBody] int ID_ESTADO)
        {
            var LstCitas = _citasServices.GetCITASESTADO(ID_ESTADO);

            return Ok(LstCitas);
        }
    }
}
