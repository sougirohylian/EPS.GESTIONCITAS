using EPS.GESTIONCITAS.RECETASDataAccess.Model;
using EPS.GESTIONCITAS.RECETASDataAccess.Repositories;
using EPS.GESTIONCITAS.RECETASLogic.Services.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.RECETASLogic.Services
{
    public interface IEstadosRecetaServices
    {
        Task<ServiceResult<List<ESTADOS_RECETAS>>> GetAllESTADOSRECETAS();
        string InsEstadosRecetas(ESTADOS_RECETAS estadosRecetas);
        string UpsEstadosRecetas(ESTADOS_RECETAS estadosRecetas);
        string DelEstadosRecetas(ESTADOS_RECETAS estadosRecetas);
    }
    public class EstadosRecetaServices : IEstadosRecetaServices
    {
        private readonly IEstadoRecetaRepository _estadoRecetasRepository;
        private readonly ILogger<EstadosRecetaServices> _logger;
        public EstadosRecetaServices(IEstadoRecetaRepository estadoRecetasRepository, ILogger<EstadosRecetaServices> logger)
        {
            _estadoRecetasRepository = estadoRecetasRepository;
            _logger = logger;
        }
        public async Task<ServiceResult<List<ESTADOS_RECETAS>>> GetAllESTADOSRECETAS()
        {
            ServiceResult<List<ESTADOS_RECETAS>> result = new ServiceResult<List<ESTADOS_RECETAS>>()
            {
                Extras = new List<ESTADOS_RECETAS>()
            };
            var citas = await _estadoRecetasRepository.GetAllESTADOSRECETAS();
            result.Extras = citas;
            result.Success = true;
            return result;
        }
        public string InsEstadosRecetas(ESTADOS_RECETAS estadosRecetas)
        {
            string result = string.Empty;
            if (estadosRecetas != null)
            {
                result = _estadoRecetasRepository.InsEstadosRecetas(estadosRecetas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string UpsEstadosRecetas(ESTADOS_RECETAS estadosRecetas)
        {
            string result = string.Empty;
            if (estadosRecetas != null)
            {
                result = _estadoRecetasRepository.UpsEstadosRecetas(estadosRecetas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string DelEstadosRecetas(ESTADOS_RECETAS estadosRecetas)
        {
            string result = string.Empty;
            if (estadosRecetas != null)
            {
                result = _estadoRecetasRepository.DelEstadosRecetas(estadosRecetas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
    }
}
