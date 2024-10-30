using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services;
using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Model;
using EPS.GESTIONCITAS.Clinicas.WebApi.Controllers;

namespace EPS.GESTIONCITAS.tipoPersonas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipotipoPersonasController : Controller
    {
        private readonly ILogger<TipotipoPersonasController> _logger;
        private readonly ITipoPersonasServices _tipoPersonasServices;
        public TipotipoPersonasController(ILogger<TipotipoPersonasController> logger, ITipoPersonasServices tipoPersonasServices)
        {
            _logger = logger;
            _tipoPersonasServices = tipoPersonasServices;
        }
        [HttpGet(Name = "GetTipoPersonas")]
        public async Task<IActionResult> GetAlltipoPersonas()
        {
            var LstTipoPersonas = await _tipoPersonasServices.GetAllTipoPersonas();

            return Ok(LstTipoPersonas);
        }
        [HttpPost(Name = "PostTipoPersonas")]
        public IActionResult PostTipoPersonas([FromBody] TIPO_PERSONAS tipoPersona)
        {
            var LsttipoPersonas = _tipoPersonasServices.InsTipoPersona(tipoPersona);

            return Ok(LsttipoPersonas);
        }
        [HttpPut(Name = "PutTipoPersonas")]
        public IActionResult PutTipoPersonas([FromBody] TIPO_PERSONAS tipoPersona)
        {
            var LsttipoPersonas = _tipoPersonasServices.UpsTipoPersona(tipoPersona);

            return Ok(LsttipoPersonas);
        }
        [HttpDelete(Name = "DelTipoPersonas")]
        public IActionResult DelTipoPersonas([FromBody] TIPO_PERSONAS tipoPersona)
        {
            var LsttipoPersonas = _tipoPersonasServices.DelTipoPersona(tipoPersona);

            return Ok(LsttipoPersonas);
        }
    }
}
