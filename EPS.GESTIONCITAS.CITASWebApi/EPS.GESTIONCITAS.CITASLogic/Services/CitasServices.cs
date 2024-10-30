using EPS.GESTIONCITAS.CITASDataAccess.Model;
using EPS.GESTIONCITAS.CITASDataAccess.Repositories;
using EPS.GESTIONCITAS.CITASLogic.DTO;
using EPS.GESTIONCITAS.CITASLogic.Services.Base;
using EPS.GESTIONCITAS.CITASLogic.Settings;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.CITASLogic.Services
{
    public interface ICitasServices
    {
        Task<ServiceResult<List<CITAS>>> GetAllCITAS();
        Task<ServiceResult<List<CITAS>>> GetCITASESTADO(int ID_ESTADO);
        string InsCitas(CITAS citas);
        string UpsCitas(CITAS citas);
        string DelCitas(CITAS citas);
        Task<ServiceResult<PersonasDTO>> ObtenerPersonas();
        Task<ServiceResult<RecetasDTO>> RegistrarReceta(RecetasDTO receta);
    }
    public class CitasServices : ICitasServices
    {
        private readonly ICitasRepository _citasRepository;
        private readonly ILogger<ICitasServices> _logger;
        private readonly IGlobalSettings globalSettings;
        private readonly IConsumerService consumerService;
        public CitasServices(ICitasRepository citasRepository, ILogger<CitasServices> logger, IGlobalSettings globalSettings, IConsumerService consumerService)
        {
            _citasRepository = citasRepository;
            _logger = logger;
            this.globalSettings = globalSettings;
            this.consumerService = consumerService;
        }
        public async Task<ServiceResult<List<CITAS>>> GetAllCITAS()
        {
            ServiceResult<List<CITAS>> result = new ServiceResult<List<CITAS>>()
            {
                Extras = new List<CITAS>()
            };
            var citas = await _citasRepository.GetAllCITAS();
            result.Extras = citas;
            result.Success = true;
            return result;
        }
        public async Task<ServiceResult<List<CITAS>>> GetCITASESTADO(int ID_ESTADO)
        {
            ServiceResult<List<CITAS>> result = new ServiceResult<List<CITAS>>()
            {
                Extras = new List<CITAS>()
            };
            var citas = await _citasRepository.GetCITASESTADO(ID_ESTADO);
            result.Extras = citas;
            result.Success = true;
            return result;
        }
        public string InsCitas(CITAS citas)
        {
            string result = string.Empty;
            if (citas != null)
            {
                result = _citasRepository.InsCitas(citas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string UpsCitas(CITAS citas)
        {
            string result = string.Empty;
            if (citas != null)
            {
                result = _citasRepository.UpsCitas(citas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string DelCitas(CITAS citas)
        {
            string result = string.Empty;
            if (citas != null)
            {
                result = _citasRepository.DelCitas(citas);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public async Task<ServiceResult<PersonasDTO>> ObtenerPersonas()
        {
            var result = new ServiceResult<PersonasDTO>();
            string url = "https://localhost:44342/api/Personas";
            try
            {
                PersonasDTO personas = new PersonasDTO();
                var dataResponse = await consumerService.SendPostAsync(url, personas, "No existen datos registrados");
                if (!dataResponse.Success)
                {
                    var data = dataResponse.Extras;
                    _logger.LogError("No es posible consultar las personas: {data}", data);
                    result.Errors.AddRange(dataResponse.Errors);
                }
                else
                {
                    var data = JsonConvert.DeserializeObject<PersonasDTO>(dataResponse.Extras);
                    result.Success = true;
                    result.Extras = data;
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add("Error al obtener respuesta del servidor");
                result.Errors.Add(ex.Message);
            }
            finally
            {
                result.MarkAsSuccessIfNoErrors();
            }

            return result;
        }
        public async Task<ServiceResult<RecetasDTO>> RegistrarReceta(RecetasDTO receta)
        {
            var result = new ServiceResult<RecetasDTO>();
            string url = "https://localhost:44342/api/Recetas";
            try
            {
                RecetasDTO recetas = new RecetasDTO();
                var dataResponse = await consumerService.SendPostAsync(url, recetas, "No existen datos registrados");
                if (!dataResponse.Success)
                {
                    var data = dataResponse.Extras;
                    _logger.LogError("No es posible consultar las personas: {data}", data);
                    result.Errors.AddRange(dataResponse.Errors);
                }
                else
                {
                    var data = JsonConvert.DeserializeObject<RecetasDTO>(dataResponse.Extras);
                    result.Success = true;
                    result.Extras = data;
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add("Error al obtener respuesta del servidor");
                result.Errors.Add(ex.Message);
            }
            finally
            {
                result.MarkAsSuccessIfNoErrors();
            }

            return result;
        }
    }
}
