using EPS.GESTIONCITAS.RECETASDataAccess.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.RECETASDataAccess.Repositories
{
    public interface IRecetasRepository
    {
        /// <summary>
        /// Obtiene la información de las recetas registradas
        /// </summary>
        /// <param >Sin parametro</param>
        Task<List<RECETAS>> GetAllRECETAS();
        /// <summary>
        /// Registra en la tabla una receta
        /// </summary>
        /// <param>Persona</param>
        string InsRecetas(RECETAS recetas);
        /// <summary>
        /// Actualiza en la tabla una receta
        /// </summary>
        /// <param>Persona</param>
        string UpsRecetas(RECETAS recetas);
        /// <summary>
        /// Elimina un registro de la tabla
        /// </summary>
        /// <param>Persona</param>
        string DelRecetas(RECETAS recetas);
    }
    public class RecetasRepository : IRecetasRepository
    {
        private readonly ILogger<RecetasRepository> _logger;
        private readonly Entities _appDbContext;
        public RecetasRepository(ILogger<RecetasRepository> logger, Entities appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        public async Task<List<RECETAS>> GetAllRECETAS()
        {
            var result = await _appDbContext.RECETAS.ToListAsync();

            return result;
        }
        public string InsRecetas(RECETAS recetas)
        {
            string result = string.Empty;
            try
            {
                _appDbContext.RECETAS.Add(recetas);
                _appDbContext.SaveChanges();
                result = "Receta registrada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public string UpsRecetas(RECETAS recetas)
        {
            string result = string.Empty;
            try
            {
                RECETAS recetaAnt = _appDbContext.RECETAS.FirstOrDefault(x => x.ID_RECETA.Equals(recetas.ID_RECETA));
                recetaAnt.ID_ESTADO = recetas.ID_ESTADO;
                recetaAnt.DESCRIPCION = recetas.DESCRIPCION;
                recetaAnt.ID_MEDICO = recetas.ID_MEDICO;
                _appDbContext.SaveChanges();
                result = "Receta actualizada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        public string DelRecetas(RECETAS recetas)
        {
            string result = string.Empty;
            try
            {
                RECETAS lastReceta = _appDbContext.RECETAS.FirstOrDefault(x => x.ID_RECETA.Equals(recetas.ID_RECETA));
                _appDbContext.RECETAS.Remove(lastReceta);
                _appDbContext.SaveChanges();
                result = "Receta eliminada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return string.Empty;
        }
    }
}
