using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace EPS.GESTIONCITAS.PERSONAS.Controllers
{
    /// <summary>
    /// Controller
    /// </summary>
    [RoutePrefix("api/personas")]
    public class PersonasController : ApiController
    {
        private readonly ILogger<PersonasController> _logger;
        private readonly IPersonasServices _personasServices;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="PersonasServices"></param>
        /// <param name="log"></param>
        // Ninject inyecta el servicio en el constructor
        public PersonasController(IPersonasServices personasService)
        {
            _personasServices = personasService;
        }
        // GET: Personas
        /*public ActionResult Index()
        {
            return View();
        }*/
        /// <summary>
        /// Consulta cuenta de cliente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task<IActionResult> GetAllPersonas()
        { 
            var LstPersonas = await _personasServices.GetAllPersonas();

            return (IActionResult)LstPersonas;
        }
        [HttpGet]
        [Route("api/personas")]
        public IHttpActionResult GetPersonas()
        {
            var personas = _personasServices.GetAllPersonas();
            return Ok(personas);
        }

    }
}