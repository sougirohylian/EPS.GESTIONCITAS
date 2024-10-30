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
    public interface ITipoPersonasServices
    {
        Task<ServiceResult<List<TIPO_PERSONAS>>> GetAllTipoPersonas();
        string InsTipoPersona(TIPO_PERSONAS tipoPersona);
        string UpsTipoPersona(TIPO_PERSONAS tipoPersona);
        string DelTipoPersona(TIPO_PERSONAS tipoPersona);
    }
    public class TipoPersonasServices : ITipoPersonasServices
    {
        private readonly ILogger<TipoPersonasServices> _logger;
        private readonly ITipoPersonasRepository _tipoPersonasRepository;

        public TipoPersonasServices(ILogger<TipoPersonasServices> logger, TipoPersonasRepository tipoPersonasRepository)
        {
            _logger = logger;
            _tipoPersonasRepository = tipoPersonasRepository;
        }
        public async Task<ServiceResult<List<TIPO_PERSONAS>>> GetAllTipoPersonas()
        {
            ServiceResult<List<TIPO_PERSONAS>> result = new ServiceResult<List<TIPO_PERSONAS>>()
            {
                Extras = new List<TIPO_PERSONAS>()
            };
            var tipoPersonas = await _tipoPersonasRepository.GetAllTIPOPERSONAS();
            result.Extras = tipoPersonas;
            result.Success = true;
            return result;
        }
        public string InsTipoPersona(TIPO_PERSONAS tipoPersona)
        {
            string result = string.Empty;
            if (tipoPersona != null)
            {
                result = _tipoPersonasRepository.InsTipoPersona(tipoPersona);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string UpsTipoPersona(TIPO_PERSONAS tipoPersona)
        {
            string result = string.Empty;
            if (tipoPersona != null)
            {
                result = _tipoPersonasRepository.UpsTipoPersona(tipoPersona);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
        public string DelTipoPersona(TIPO_PERSONAS tipoPersona)
        {
            string result = string.Empty;
            if (tipoPersona != null)
            {
                result = _tipoPersonasRepository.DelTipoPersona(tipoPersona);
            }
            else
            {
                result = "El objeto persona esta vació";
            }
            return result;
        }
    }
}
