using EPS.GESTIONCITAS.CITASDataAccess.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.CITASDataAccess.Repositories
{
    public interface IEstadosCitasRepository {
        /// <summary>
        /// Obtiene la información de los estados de las citas registradas
        /// </summary>
        /// <param >Sin parametro</param>
        Task<List<ESTADOS_CITAS>> GetAllESTADOSCITAS();
        /// <summary>
        /// Registra en la tabla un estado de cita
        /// </summary>
        /// <param>Persona</param>
        string InsEstadosCitas(ESTADOS_CITAS estadosCitas);
        /// <summary>
        /// Actualiza en la tabla un estado de cita
        /// </summary>
        /// <param>Persona</param>
        string UpsEstadosCitas(ESTADOS_CITAS estadosCitas);
        /// <summary>
        /// Elimina un registro de la tabla
        /// </summary>
        /// <param>Persona</param>
        string DelEstadosCitas(ESTADOS_CITAS estadosCitas);
    }
    public class EstadosCitasRepository : IEstadosCitasRepository
    {
        private readonly ILogger<EstadosCitasRepository> _logger;
        private readonly EntitiesCitas _appDbContext;
        public EstadosCitasRepository(ILogger<EstadosCitasRepository> logger, EntitiesCitas appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        public async Task<List<ESTADOS_CITAS>> GetAllESTADOSCITAS()
        {
            var result = await _appDbContext.ESTADOS_CITAS.ToListAsync();

            return result;
        }
        public string InsEstadosCitas(ESTADOS_CITAS estadosCitas)
        {
            string result = string.Empty;
            try
            {
                _appDbContext.ESTADOS_CITAS.Add(estadosCitas);
                _appDbContext.SaveChanges();
                result = "Estado de la Cita registrada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public string UpsEstadosCitas(ESTADOS_CITAS estadosCitas)
        {
            string result = string.Empty;
            try
            {
                ESTADOS_CITAS estadocitaAnt = _appDbContext.ESTADOS_CITAS.FirstOrDefault(x => x.ID_ESTADO_CITA.Equals(estadosCitas.ID_ESTADO_CITA));
                estadocitaAnt.NOMBRE = estadosCitas.NOMBRE;
                estadocitaAnt.DESCRIPCION = estadosCitas.DESCRIPCION;
                _appDbContext.SaveChanges();
                result = "Estado de la Cita actualizada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        public string DelEstadosCitas(ESTADOS_CITAS estadosCitas)
        {
            string result = string.Empty;
            try
            {
                ESTADOS_CITAS lastCita = _appDbContext.ESTADOS_CITAS.FirstOrDefault(x => x.ID_ESTADO_CITA.Equals(estadosCitas.ID_ESTADO_CITA));
                _appDbContext.ESTADOS_CITAS.Remove(lastCita);
                _appDbContext.SaveChanges();
                result = "Estado de la Cita eliminada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return string.Empty;
        }
    }
}
