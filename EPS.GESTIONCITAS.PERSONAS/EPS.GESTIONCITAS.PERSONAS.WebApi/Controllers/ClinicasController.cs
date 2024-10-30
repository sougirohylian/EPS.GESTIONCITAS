using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services;
using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Model;
namespace EPS.GESTIONCITAS.Clinicas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClinicasController : Controller
    {
        private readonly ILogger<ClinicasController> _logger;
        private readonly IClinicasServices _clinicasServices;
        public ClinicasController(ILogger<ClinicasController> logger, IClinicasServices clinicasServices)
        {
            _logger = logger;
            _clinicasServices = clinicasServices;
        }
        [HttpGet(Name = "GetClinicas")]
        public async Task<IActionResult> GetAllClinicas()
        {
            var LstClinicas = await _clinicasServices.GetAllClinicas();

            return Ok(LstClinicas);
        }
        [HttpPost(Name = "PostClinicas")]
        public IActionResult PostClinicas([FromBody] CLINICAS clinicas)
        {
            var LstClinicas = _clinicasServices.InsClinicas(clinicas);

            return Ok(LstClinicas);
        }
        [HttpPut(Name = "PutClinicas")]
        public IActionResult PutClinicas([FromBody] CLINICAS clinicas)
        {
            var LstClinicas = _clinicasServices.UpsClinicas(clinicas);

            return Ok(LstClinicas);
        }
        [HttpDelete(Name = "DelClinicas")]
        public IActionResult DelClinicas([FromBody] CLINICAS clinicas)
        {
            var LstClinicas = _clinicasServices.DelClinicas(clinicas);

            return Ok(LstClinicas);
        }
    }
}
