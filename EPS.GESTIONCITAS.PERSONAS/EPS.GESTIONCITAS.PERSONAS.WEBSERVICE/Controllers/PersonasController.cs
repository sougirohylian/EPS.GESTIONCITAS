using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EPS.GESTIONCITAS.PERSONAS.WEBSERVICE.Controllers
{
    public class PersonasController : ApiController
    {
        private readonly IPersonasServices _personasService;
        // Ninject inyecta el servicio en el constructor
        public PersonasController(IPersonasServices personasService)
        {
            _personasService = personasService;
        }
        // GET: Personas
        [HttpGet]
        [Route("api/personas")]
        public IHttpActionResult GetPersonas()
        {
            var personas = _personasService.GetAllPersonas();
            return Ok(personas);
        }
    }
}