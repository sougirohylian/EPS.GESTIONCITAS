using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Model;
using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Repositories;
using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services.Base;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.PERSONAS.LOGIC.Services
{
    public interface IClinicasServices
    {
        Task<ServiceResult<List<CLINICAS>>> GetAllClinicas();
        string InsClinicas(CLINICAS Clinicas);
        string UpsClinicas(CLINICAS Clinicas);
        string DelClinicas(CLINICAS Clinicas);
    }
    public class ClinicasServices
    {
        private readonly ILogger<ClinicasServices> _logger;
        private readonly IClinicasRepository _clinicasRepository;

        public ClinicasServices(ILogger<ClinicasServices> logger, ClinicasRepository clinicasRepository)
        {
            _logger = logger;
            _clinicasRepository = clinicasRepository;
        }
        public async Task<ServiceResult<List<CLINICAS>>> GetAllClinicas()
        {
            ServiceResult<List<CLINICAS>> result = new ServiceResult<List<CLINICAS>>()
            {
                Extras = new List<CLINICAS>()
            };
            var clinicas = await _clinicasRepository.GetAllCLINICAS();
            result.Extras = clinicas;
            result.Success = true;
            return result;
        }
        public string InsClinicas(CLINICAS clinicas)
        {
            string result = string.Empty;
            if (clinicas != null)
            {
                result = _clinicasRepository.InsClinicas(clinicas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string UpsClinicas(CLINICAS clinicas)
        {
            string result = string.Empty;
            if (clinicas != null)
            {
                result = _clinicasRepository.UpsClinica(clinicas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string DelClinicas(CLINICAS clinicas)
        {
            string result = string.Empty;
            if (clinicas != null)
            {
                result = _clinicasRepository.DelClinicas(clinicas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
    }
}
