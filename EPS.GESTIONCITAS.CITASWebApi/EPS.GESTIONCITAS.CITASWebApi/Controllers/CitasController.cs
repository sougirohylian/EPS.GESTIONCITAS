using EPS.GESTIONCITAS.CITASDataAccess.Model;
using EPS.GESTIONCITAS.CITASLogic.DTO;
using EPS.GESTIONCITAS.CITASLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EPS.GESTIONCITAS.CITASWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CitasController : ControllerBase
    {
        private readonly ILogger<CitasController> _logger;
        private readonly ICitasServices _citasServices;
        public CitasController(ILogger<CitasController> logger, ICitasServices citasServices)
        {
            _logger = logger;
            _citasServices = citasServices;
        }
        [HttpGet(Name = "GetCitas")]
        public async Task<IActionResult> GetAllCitas()
        {
            var LstCitas = await _citasServices.GetAllCITAS();

            return Ok(LstCitas);
        }
        [HttpPost(Name = "PostCitas")]
        public IActionResult PostCitas([FromBody] CITAS Citas)
        {
            var LstCitas = _citasServices.InsCitas(Citas);

            return Ok(LstCitas);
        }
        [HttpPut(Name = "PutCitas")]
        public IActionResult PutCitas([FromBody] CITAS Citas)
        {
            var LstPersonas = _citasServices.UpsCitas(Citas);

            return Ok(LstPersonas);
        }
        [HttpDelete(Name = "DelCitas")]
        public IActionResult DelCitas([FromBody] CITAS Citas)
        {
            var LstPersonas = _citasServices.DelCitas(Citas);

            return Ok(LstPersonas);
        }
       
    }
}
