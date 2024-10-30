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
    public interface IClinicasRepository
    {
        /// <summary>
        /// Obtiene la información de las clinicas registradas
        /// </summary>
        /// <param >Sin parametro</param>
        Task<List<CLINICAS>> GetAllCLINICAS();
        /// <summary>
        /// Registra en la tabla una clinica
        /// </summary>
        /// <param>clinica</param>
        string InsClinicas(CLINICAS Clinicas);
        /// <summary>
        /// Actualiza en la tabla una clinica
        /// </summary>
        /// <param>clinica</param>
        string UpsClinica(CLINICAS Clinicas);
        /// <summary>
        /// Elimina un registro de la tabla
        /// </summary>
        /// <param>Clinica</param>
        string DelClinicas(CLINICAS Clinicas);
    }
    public class ClinicasRepository : IClinicasRepository
    {
        private readonly ILogger<ClinicasRepository> _logger;
        private readonly EntitiesPersonas _appDbContext;

        public ClinicasRepository(ILogger<ClinicasRepository> logger, EntitiesPersonas appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        public async Task<List<CLINICAS>> GetAllCLINICAS()
        {
            var result = await _appDbContext.CLINICAS.ToListAsync();

            return result;
        }
        public string InsClinicas(CLINICAS Clinicas)
        {
            string result = string.Empty;
            try
            {
                _appDbContext.CLINICAS.Add(Clinicas);
                _appDbContext.SaveChanges();
                result = "Clinica registrada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public string UpsClinica(CLINICAS Clinicas)
        {
            string result = string.Empty;
            try
            {
                CLINICAS clinicaAnt = _appDbContext.CLINICAS.FirstOrDefault(x => x.ID_CLINICA.Equals(Clinicas.ID_CLINICA));
                clinicaAnt.DIRECCION = Clinicas.DIRECCION;
                clinicaAnt.NOMBRE = Clinicas.NOMBRE;
                _appDbContext.SaveChanges();
                result = "Clinica actualizada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        public string DelClinicas(CLINICAS Clinicas)
        {
            string result = string.Empty;
            try
            {
                CLINICAS lastClinica = _appDbContext.CLINICAS.FirstOrDefault(x => x.ID_CLINICA.Equals(Clinicas.ID_CLINICA));
                _appDbContext.CLINICAS.Remove(lastClinica);
                _appDbContext.SaveChanges();
                result = "Clinica eliminada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return string.Empty;
        }
    }
}
