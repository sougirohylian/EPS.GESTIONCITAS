using EPS.GESTIONCITAS.CITASDataAccess.Model;
using EPS.GESTIONCITAS.CITASDataAccess.Repositories;
using EPS.GESTIONCITAS.CITASLogic.Services.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.CITASLogic.Services
{
    public interface IEstadosCitaServices
    {
        Task<ServiceResult<List<ESTADOS_CITAS>>> GetAllESTADOSCITAS();
        string InsEstadosCitas(ESTADOS_CITAS estadosCitas);
        string UpsEstadosCitas(ESTADOS_CITAS estadosCitas);
        string DelEstadosCitas(ESTADOS_CITAS estadosCitas);
    }
    public class EstadosCitaServices : IEstadosCitaServices
    {
        private readonly IEstadosCitasRepository _estadosCitasRepository;
        private readonly ILogger<IEstadosCitaServices> _logger;
        public EstadosCitaServices(IEstadosCitasRepository estadosCitasRepository, ILogger<EstadosCitaServices> logger)
        {
            _estadosCitasRepository = estadosCitasRepository;
            _logger = logger;
        }
        public async Task<ServiceResult<List<ESTADOS_CITAS>>> GetAllESTADOSCITAS()
        {
            ServiceResult<List<ESTADOS_CITAS>> result = new ServiceResult<List<ESTADOS_CITAS>>()
            {
                Extras = new List<ESTADOS_CITAS>()
            };
            var citas = await _estadosCitasRepository.GetAllESTADOSCITAS();
            result.Extras = citas;
            result.Success = true;
            return result;
        }
        public string InsEstadosCitas(ESTADOS_CITAS estadosCitas)
        {
            string result = string.Empty;
            if (estadosCitas != null)
            {
                result = _estadosCitasRepository.InsEstadosCitas(estadosCitas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string UpsEstadosCitas(ESTADOS_CITAS estadosCitas)
        {
            string result = string.Empty;
            if (estadosCitas != null)
            {
                result = _estadosCitasRepository.UpsEstadosCitas(estadosCitas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string DelEstadosCitas(ESTADOS_CITAS estadosCitas)
        {
            string result = string.Empty;
            if (estadosCitas != null)
            {
                result = _estadosCitasRepository.DelEstadosCitas(estadosCitas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
    }
}
