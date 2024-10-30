using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Model;
using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Repositories;
using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services.Base;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.PERSONAS.LOGIC.Services
{
    public interface IPersonasServices
    {
        Task<ServiceResult<List<DATAACCESS.Model.PERSONAS>>> GetAllPersonas();
        Task<ServiceResult<List<DATAACCESS.Model.PERSONAS>>> GetPERSONASTIPO(int ID_TIPO);
        string InsPersona(DATAACCESS.Model.PERSONAS persona);
        string UpsPersona(DATAACCESS.Model.PERSONAS persona);
        string DelPersona(DATAACCESS.Model.PERSONAS persona);
    }
    public class PersonasServices : IPersonasServices
    {
        private readonly IPersonasRepository _personasRepository;
        private readonly ILogger<IPersonasServices> _logger;
        public PersonasServices(IPersonasRepository personasRepository, ILogger<PersonasServices> logger)
        {
            _personasRepository = personasRepository;
            _logger = logger;
        }
        public async Task<ServiceResult<List<DATAACCESS.Model.PERSONAS>>> GetAllPersonas()
        {
            ServiceResult<List<DATAACCESS.Model.PERSONAS>> result = new ServiceResult<List<DATAACCESS.Model.PERSONAS>>()
            {
                Extras = new List<DATAACCESS.Model.PERSONAS>()
            };
            var personas = await _personasRepository.GetAllPERSONAS();
            result.Extras = personas;
            result.Success = true;
            return result;
        }
        public async Task<ServiceResult<List<DATAACCESS.Model.PERSONAS>>> GetPERSONASTIPO(int ID_TIPO)
        {
            ServiceResult<List<DATAACCESS.Model.PERSONAS>> result = new ServiceResult<List<DATAACCESS.Model.PERSONAS>>()
            {
                Extras = new List<DATAACCESS.Model.PERSONAS>()
            };
            var personas = await _personasRepository.GetPERSONASTIPO(ID_TIPO);
            result.Extras = personas;
            result.Success = true;
            return result;
        }
        public string InsPersona(DATAACCESS.Model.PERSONAS persona)
        {
            string result = string.Empty;
            if (persona != null)
            {
                result = _personasRepository.InsPersona(persona);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string UpsPersona(DATAACCESS.Model.PERSONAS persona)
        {
            string result = string.Empty;
            if (persona != null)
            {
                result = _personasRepository.UpsPersona(persona);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string DelPersona(DATAACCESS.Model.PERSONAS persona)
        {
            string result = string.Empty;
            if (persona != null)
            {
                result = _personasRepository.DelPersona(persona);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
    }
}
