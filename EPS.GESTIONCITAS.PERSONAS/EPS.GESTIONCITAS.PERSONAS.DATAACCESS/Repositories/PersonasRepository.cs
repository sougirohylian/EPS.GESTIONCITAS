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
    public interface IPersonasRepository
    {
        /// <summary>
        /// Obtiene la información de las personas registradas
        /// </summary>
        /// <param >Sin parametro</param>
        Task<List<Model.PERSONAS>> GetAllPERSONAS();
        /// <summary>
        /// Obtiene la información de las personas registradas por tipo
        /// </summary>
        /// <param >ID Tipo Persona</param>
        Task<List<Model.PERSONAS>> GetPERSONASTIPO(int ID_TIPO);
        /// <summary>
        /// Registra en la tabla una persona
        /// </summary>
        /// <param>Persona</param>
        string InsPersona(DATAACCESS.Model.PERSONAS Persona);
        /// <summary>
        /// Actualiza en la tabla una persona
        /// </summary>
        /// <param>Persona</param>
        string UpsPersona(DATAACCESS.Model.PERSONAS Persona);
        /// <summary>
        /// Elimina un registro de la tabla
        /// </summary>
        /// <param>Persona</param>
        string DelPersona(DATAACCESS.Model.PERSONAS Persona);
    }
    public class PersonasRepository : IPersonasRepository
    {
        private readonly ILogger<PersonasRepository> _logger;
        private readonly EntitiesPersonas _appDbContext;

        public PersonasRepository(ILogger<PersonasRepository> logger, EntitiesPersonas appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        public async Task<List<Model.PERSONAS>> GetAllPERSONAS()
        {
            var result = await _appDbContext.PERSONAS.ToListAsync();

            return result;
        }
        public async Task<List<Model.PERSONAS>> GetPERSONASTIPO(int ID_TIPO)
        {
            List<Model.PERSONAS> lstPersonasTipo = new List<Model.PERSONAS>();
            lstPersonasTipo = _appDbContext.PERSONAS.Where(x=> x.ID_TIPO_PERSONA == ID_TIPO).ToList();

            return lstPersonasTipo;
        }
        public string InsPersona(DATAACCESS.Model.PERSONAS Persona)
        {
            string result = string.Empty;
            try
            {
                _appDbContext.PERSONAS.Add(Persona);
                _appDbContext.SaveChanges();
                result = "Persona registrada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public string UpsPersona(DATAACCESS.Model.PERSONAS Persona) 
        { 
            string result = string.Empty ;
            try
            {
                Model.PERSONAS personaAnt = _appDbContext.PERSONAS.FirstOrDefault(x => x.ID_PERSONA.Equals(Persona.ID_PERSONA));
                personaAnt.NOMBRES = Persona.NOMBRES;
                personaAnt.APELLIDOS = Persona.APELLIDOS;
                personaAnt.FECHA_NACIMIENTO = Persona.FECHA_NACIMIENTO;
                personaAnt.CEDULA = Persona.CEDULA;
                personaAnt.ID_TIPO_PERSONA = Persona.ID_TIPO_PERSONA;
                _appDbContext.SaveChanges();
                result = "Persona actualizada con exito";
            }
            catch (Exception ex) 
            {
                result = ex.Message;
            }
            
            return result; 
        }
        public string DelPersona(DATAACCESS.Model.PERSONAS Persona) 
        { 
            string result = string.Empty ;
            try
            {
                Model.PERSONAS lastPerson = _appDbContext.PERSONAS.FirstOrDefault(x => x.ID_PERSONA.Equals(Persona.ID_PERSONA));
                _appDbContext.PERSONAS.Remove(lastPerson);
                _appDbContext.SaveChanges();
                result = "Persona eliminada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return string.Empty ; 
        }
    }
}
