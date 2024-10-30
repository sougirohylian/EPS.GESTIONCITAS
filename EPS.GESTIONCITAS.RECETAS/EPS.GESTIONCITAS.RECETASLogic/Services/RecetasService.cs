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
    public interface IRecetasService
    {
        Task<ServiceResult<List<RECETAS>>> GetAllRECETAS();
        string InsRecetas(RECETAS recetas);
        string UpsRecetas(RECETAS recetas);
        string DelRecetas(RECETAS recetas);
    }
    public class RecetasService : IRecetasService
    {
        private readonly IRecetasRepository _recetasRepository;
        private readonly ILogger<RecetasService> _logger;
        public RecetasService(IRecetasRepository recetasRepository, ILogger<RecetasService> logger)
        {
            _recetasRepository = recetasRepository;
            _logger = logger;
        }
        public async Task<ServiceResult<List<RECETAS>>> GetAllRECETAS()
        {
            ServiceResult<List<RECETAS>> result = new ServiceResult<List<RECETAS>>()
            {
                Extras = new List<RECETAS>()
            };
            var citas = await _recetasRepository.GetAllRECETAS();
            result.Extras = citas;
            result.Success = true;
            return result;
        }
        public string InsRecetas(RECETAS recetas)
        {
            string result = string.Empty;
            if (recetas != null)
            {
                result = _recetasRepository.InsRecetas(recetas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string UpsRecetas(RECETAS recetas)
        {
            string result = string.Empty;
            if (recetas != null)
            {
                result = _recetasRepository.UpsRecetas(recetas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string DelRecetas(RECETAS recetas)
        {
            string result = string.Empty;
            if (recetas != null)
            {
                result = _recetasRepository.DelRecetas(recetas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
    }
}
