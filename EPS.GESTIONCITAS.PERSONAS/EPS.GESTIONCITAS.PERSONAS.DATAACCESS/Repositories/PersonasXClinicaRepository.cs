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
    public interface IPersonasXClinicaRepository
    {
        /// <summary>
        /// Obtiene la información de las personas por clinica registradas
        /// </summary>
        /// <param >Sin parametro</param>
        Task<List<PERSONAS_X_CLINICA>> GetAllPERSONASXCLINICA();
        /// <summary>
        /// Registra en la tabla una persona por clinica
        /// </summary>
        /// <param>Persona</param>
        string InsPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica);
        /// <summary>
        /// Actualiza en la tabla una persona por clinica
        /// </summary>
        /// <param>Persona</param>
        string UpsPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica);
        /// <summary>
        /// Elimina un registro de la tabla
        /// </summary>
        /// <param>Persona</param>
        string DelPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica);
    }
    public class PersonasXClinicaRepository : IPersonasXClinicaRepository
    {
        private readonly ILogger<PersonasXClinicaRepository> _logger;
        private readonly EntitiesPersonas _appDbContext;

        public PersonasXClinicaRepository(ILogger<PersonasXClinicaRepository> logger, EntitiesPersonas appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        public async Task<List<PERSONAS_X_CLINICA>> GetAllPERSONASXCLINICA()
        {
            var result = await _appDbContext.PERSONAS_X_CLINICA.ToListAsync();

            return result;
        }
        public string InsPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica)
        {
            string result = string.Empty;
            try
            {
                _appDbContext.PERSONAS_X_CLINICA.Add(PersonaxClinica);
                _appDbContext.SaveChanges();
                result = "Persona por clinica registrada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public string UpsPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica)
        {
            string result = string.Empty;
            try
            {
                PERSONAS_X_CLINICA PersonaAnt = _appDbContext.PERSONAS_X_CLINICA.FirstOrDefault(x => x.ID_PERSONAS_X_CLINICA
                .Equals(PersonaxClinica.ID_PERSONAS_X_CLINICA));
                PersonaAnt.ID_PERSONA = PersonaxClinica.ID_PERSONA;
                PersonaAnt.ID_CLINICA = PersonaxClinica.ID_CLINICA;
                _appDbContext.SaveChanges();
                result = "Persona por clinica actualizada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        public string DelPersonasxClinca(PERSONAS_X_CLINICA PersonaxClinica)
        {
            string result = string.Empty;
            try
            {
                PERSONAS_X_CLINICA lastPerson = _appDbContext.PERSONAS_X_CLINICA.FirstOrDefault(x => x.ID_PERSONAS_X_CLINICA
                .Equals(PersonaxClinica.ID_PERSONAS_X_CLINICA));
                _appDbContext.PERSONAS_X_CLINICA.Remove(lastPerson);
                _appDbContext.SaveChanges();
                result = "Persona por clinica eliminada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return string.Empty;
        }
    }
}
