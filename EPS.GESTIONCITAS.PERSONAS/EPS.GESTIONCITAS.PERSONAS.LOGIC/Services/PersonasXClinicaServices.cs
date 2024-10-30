using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Model;
using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Repositories;
using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.PERSONAS.LOGIC.Services
{
    public interface IPersonasXClinicaServices
    {
        Task<ServiceResult<List<PERSONAS_X_CLINICA>>> GetAllPERSONASXCLINICA();
        string InsPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica);
        string UpsPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica);
        string DelPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica);
    }
    public class PersonasXClinicaServices : IPersonasXClinicaServices
    {
        private readonly ILogger<PersonasXClinicaServices> _logger;
        private readonly IPersonasXClinicaRepository _personasxClinicaRepository;

        public PersonasXClinicaServices(ILogger<PersonasXClinicaServices> logger, PersonasXClinicaRepository personasxClinicaRepository)
        {
            _logger = logger;
            _personasxClinicaRepository = personasxClinicaRepository;
        }
        public async Task<ServiceResult<List<PERSONAS_X_CLINICA>>> GetAllPERSONASXCLINICA()
        {
            ServiceResult<List<PERSONAS_X_CLINICA>> result = new ServiceResult<List<PERSONAS_X_CLINICA>>()
            {
                Extras = new List<PERSONAS_X_CLINICA>()
            };
            var PersonasxClinica = await _personasxClinicaRepository.GetAllPERSONASXCLINICA();
            result.Extras = PersonasxClinica;
            result.Success = true;
            return result;
        }
        public string InsPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica)
        {
            string result = string.Empty;
            if (PersonaxClinica != null)
            {
                result = _personasxClinicaRepository.InsPersonasxClinca(PersonaxClinica);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string UpsPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica)
        {
            string result = string.Empty;
            if (PersonaxClinica != null)
            {
                result = _personasxClinicaRepository.UpsPersonasxClinca(PersonaxClinica);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string DelPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica)
        {
            string result = string.Empty;
            if (PersonaxClinica != null)
            {
                result = _personasxClinicaRepository.DelPersonasxClinca(PersonaxClinica);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
    }
}
