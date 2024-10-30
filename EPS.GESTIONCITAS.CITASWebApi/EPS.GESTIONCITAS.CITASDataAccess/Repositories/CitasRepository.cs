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
    public interface ICitasRepository
    {
        /// <summary>
        /// Obtiene la información de las citas registradas
        /// </summary>
        /// <param >Sin parametro</param>
        Task<List<CITAS>> GetAllCITAS();
        /// <summary>
        /// Obtiene la información de las citas registradas por estado
        /// </summary>
        /// <param >Sin parametro</param>
        Task<List<CITAS>> GetCITASESTADO(int ID_ESTADO);
        /// <summary>
        /// Registra en la tabla una cita
        /// </summary>
        /// <param>Persona</param>
        string InsCitas(CITAS citas);
        /// <summary>
        /// Actualiza en la tabla una cita
        /// </summary>
        /// <param>Persona</param>
        string UpsCitas(CITAS citas);
        /// <summary>
        /// Elimina un registro de la tabla
        /// </summary>
        /// <param>Persona</param>
        string DelCitas(CITAS citas);
    }
    public class CitasRepository : ICitasRepository
    {
        private readonly ILogger<CitasRepository> _logger;
        private readonly EntitiesCitas _appDbContext;
        public CitasRepository(ILogger<CitasRepository> logger, EntitiesCitas appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        public async Task<List<CITAS>> GetAllCITAS()
        {
            var result = await _appDbContext.CITAS.ToListAsync();

            return result;
        }
        public async Task<List<CITAS>> GetCITASESTADO(int ID_ESTADO)
        {
            List<CITAS> lstCitasEstados = new List<CITAS>();
            lstCitasEstados =  _appDbContext.CITAS.Where(x => x.ID_ESTADO == ID_ESTADO).ToList();

            return lstCitasEstados;
        }
        public string InsCitas(CITAS citas)
        {
            string result = string.Empty;
            try
            {
                _appDbContext.CITAS.Add(citas);
                _appDbContext.SaveChanges();
                result = "Cita registrada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public string UpsCitas(CITAS citas)
        {
            string result = string.Empty;
            try
            {
                CITAS citaAnt = _appDbContext.CITAS.FirstOrDefault(x => x.ID_CITAS.Equals(citas.ID_CITAS));
                citaAnt.FECHA_CITA = citas.FECHA_CITA;
                citaAnt.ID_PERSONA = citas.ID_PERSONA;
                citaAnt.ID_MEDICO = citas.ID_MEDICO;
                citaAnt.ID_RECETA = citas.ID_RECETA;
                _appDbContext.SaveChanges();
                result = "Cita actualizada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        public string DelCitas(CITAS citas)
        {
            string result = string.Empty;
            try
            {
                CITAS lastCita = _appDbContext.CITAS.FirstOrDefault(x => x.ID_CITAS.Equals(citas.ID_CITAS));
                _appDbContext.CITAS.Remove(lastCita);
                _appDbContext.SaveChanges();
                result = "Cita eliminada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return string.Empty;
        }
    }
}
