using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPS.GESTIONCITAS.PERSONAS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PersonasTiposController : ControllerBase
    {

        private readonly ILogger<PersonasTiposController> _logger;
        private readonly IPersonasServices _personasServices;
        public PersonasTiposController(ILogger<PersonasTiposController> logger, IPersonasServices personasServices)
        {
            _logger = logger;
            _personasServices = personasServices;
        }
        [HttpPost(Name = "GetPersonasTipos/{ID_TIPO_PERSONA}")]
        public async Task<IActionResult> GetPERSONASTIPO([FromBody] int ID_TIPO_PERSONA)
        {
            var LstPersonas = await _personasServices.GetPERSONASTIPO(ID_TIPO_PERSONA);

            return Ok(LstPersonas);
        }
    }
}
