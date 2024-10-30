using EPS.GESTIONCITAS.RECETASLogic.Services;
using Microsoft.AspNetCore.Mvc;
using EPS.GESTIONCITAS.RECETASDataAccess.Model;
using Microsoft.AspNetCore.Authorization;
namespace EPS.GESTIONCITAS.RECETAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecetasController : ControllerBase
    {
        private readonly ILogger<RecetasController> _logger;
        private readonly IRecetasService _recetasServices;
        public RecetasController(ILogger<RecetasController> logger, IRecetasService recetasServices)
        {
            _logger = logger;
            _recetasServices = recetasServices;
        }
        [HttpGet(Name = "GetRecetas")]
        public async Task<IActionResult> GetAllRecetas()
        {
            var LstCitas = await _recetasServices.GetAllRECETAS();

            return Ok(LstCitas);
        }
        [HttpPost(Name = "PostRecetas")]
        public IActionResult PostRecetas([FromBody] RECETASDataAccess.Model.RECETAS recetas)
        {
            var LstRecetas = _recetasServices.InsRecetas(recetas);

            return Ok(LstRecetas);
        }
        [HttpPut(Name = "PutRecetas")]
        public IActionResult PutRecetas([FromBody] RECETASDataAccess.Model.RECETAS recetas)
        {
            var LstPersonas = _recetasServices.UpsRecetas(recetas);

            return Ok(LstPersonas);
        }
        [HttpDelete(Name = "DelRecetas")]
        public IActionResult DelPersonas([FromBody] RECETASDataAccess.Model.RECETAS recetas)
        {
            var LstPersonas = _recetasServices.DelRecetas(recetas);

            return Ok(LstPersonas);
        }
    }
}
