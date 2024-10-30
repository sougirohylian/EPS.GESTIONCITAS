using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPS.GESTIONCITAS.PERSONAS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonasController : ControllerBase
    {
        private readonly ILogger<PersonasController> _logger;
        private readonly IPersonasServices _personasServices;
        public PersonasController(ILogger<PersonasController> logger, IPersonasServices personasServices)
        {
            _logger = logger;
            _personasServices = personasServices;
        }
        [HttpGet(Name = "GetPersonas")]
        public async Task<IActionResult> GetAllPersonas()
        {
            var LstPersonas = await _personasServices.GetAllPersonas();

            return Ok(LstPersonas);
        }
        
        [HttpPost(Name = "PostPersonas")]
        public IActionResult PostPersonas([FromBody] DATAACCESS.Model.PERSONAS Persona)
        {
            var LstPersonas = _personasServices.InsPersona(Persona);

            return Ok(LstPersonas);
        }
        [HttpPut(Name = "PutPersonas")]
        public IActionResult PutPersonas([FromBody] DATAACCESS.Model.PERSONAS Persona)
        {
            var LstPersonas = _personasServices.UpsPersona(Persona);

            return Ok(LstPersonas);
        }
        [HttpDelete(Name = "DelPersonas")]
        public IActionResult DelPersonas([FromBody] DATAACCESS.Model.PERSONAS Persona)
        {
            var LstPersonas = _personasServices.DelPersona(Persona);

            return Ok(LstPersonas);
        }
    }
}
