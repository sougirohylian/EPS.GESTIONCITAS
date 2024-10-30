using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services;
using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Model;
using EPS.GESTIONCITAS.Clinicas.WebApi.Controllers;
using EPS.GESTIONCITAS.tipoPersonas.WebApi.Controllers;

namespace EPS.GESTIONCITAS.PERSONAS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonasXClinicaController : Controller
    {
        private readonly ILogger<PersonasXClinicaController> _logger;
        private readonly IPersonasXClinicaServices _personasXClinicaServices;
        public PersonasXClinicaController(ILogger<PersonasXClinicaController> logger, PersonasXClinicaServices personasXClinicaServices)
        {
            _logger = logger;
            _personasXClinicaServices = personasXClinicaServices;
        }
        [HttpGet(Name = "GetPersonasXClinica")]
        public async Task<IActionResult> GetAllPersonasXClinica()
        {
            var LstPersonas = await _personasXClinicaServices.GetAllPERSONASXCLINICA();

            return Ok(LstPersonas);
        }
        [HttpPost(Name = "PostPersonasXClinica")]
        public IActionResult PostPersonasXClinica([FromBody] PERSONAS_X_CLINICA personasXClinica)
        {
            var LstPersonas = _personasXClinicaServices.InsPersonasxClinca(personasXClinica);

            return Ok(LstPersonas);
        }
        [HttpPut(Name = "PutPersonasXClinica")]
        public IActionResult PutPersonasXClinica([FromBody] PERSONAS_X_CLINICA personasXClinica)
        {
            var LstPersonas = _personasXClinicaServices.UpsPersonasxClinca(personasXClinica);

            return Ok(LstPersonas);
        }
        [HttpDelete(Name = "DelPersonasXClinica")]
        public IActionResult DelPersonasXClinica([FromBody] PERSONAS_X_CLINICA personasXClinica)
        {
            var LstPersonas = _personasXClinicaServices.DelPersonasxClinca(personasXClinica);

            return Ok(LstPersonas);
        }
    }
}
