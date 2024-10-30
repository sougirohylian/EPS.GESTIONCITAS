using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Repositories
{
    public interface ITipoPersonasRepository
    {
        /// <summary>
        /// Obtiene la información de los tipos de personas registradas
        /// </summary>
        /// <param >Sin parametro</param>
        Task<List<TIPO_PERSONAS>> GetAllTIPOPERSONAS();
        /// <summary>
        /// Registra en la tabla un tipo de persona
        /// </summary>
        /// <param>Persona</param>
        string InsTipoPersona(TIPO_PERSONAS tipoPersona);
        /// <summary>
        /// Actualiza en la tabla una persona
        /// </summary>
        /// <param>Persona</param>
        string UpsTipoPersona(TIPO_PERSONAS tipoPersona);
        /// <summary>
        /// Elimina un registro de la tabla
        /// </summary>
        /// <param>Persona</param>
        string DelTipoPersona(TIPO_PERSONAS tipoPersona);
    }
    public class TipoPersonasRepository : ITipoPersonasRepository
    {
        private readonly ILogger<TipoPersonasRepository> _logger;
        private readonly EntitiesPersonas _appDbContext;

        public TipoPersonasRepository(ILogger<TipoPersonasRepository> logger, EntitiesPersonas appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        public async Task<List<TIPO_PERSONAS>> GetAllTIPOPERSONAS()
        {
            var result = await _appDbContext.TIPO_PERSONAS.ToListAsync();

            return result;
        }
        public string InsTipoPersona(TIPO_PERSONAS tipoPersona)
        {
            string result = string.Empty;
            try
            {
                _appDbContext.TIPO_PERSONAS.Add(tipoPersona);
                _appDbContext.SaveChanges();
                result = "Tipo de Persona registrada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public string UpsTipoPersona(TIPO_PERSONAS tipoPersona)
        {
            string result = string.Empty;
            try
            {
                TIPO_PERSONAS tipoPersonaAnt = _appDbContext.TIPO_PERSONAS.FirstOrDefault(x => x.ID_TIPO_PERSONA.Equals(tipoPersona.ID_TIPO_PERSONA));
                tipoPersonaAnt.NOMBRE = tipoPersona.NOMBRE;
                tipoPersonaAnt.DESCRIPCION = tipoPersona.DESCRIPCION;
                _appDbContext.SaveChanges();
                result = "Tipo de Persona actualizada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        public string DelTipoPersona(TIPO_PERSONAS tipoPersona)
        {
            string result = string.Empty;
            try
            {
                TIPO_PERSONAS lastTipoPerson = _appDbContext.TIPO_PERSONAS.FirstOrDefault(x => x.ID_TIPO_PERSONA.Equals(tipoPersona.ID_TIPO_PERSONA));
                _appDbContext.TIPO_PERSONAS.Remove(lastTipoPerson);
                _appDbContext.SaveChanges();
                result = "Tipo de Persona eliminada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return string.Empty;
        }
    }
}
