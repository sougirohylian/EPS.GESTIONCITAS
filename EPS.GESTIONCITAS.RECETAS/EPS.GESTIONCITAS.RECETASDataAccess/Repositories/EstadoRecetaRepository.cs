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
    public interface IEstadoRecetaRepository
    {
        /// <summary>
        /// Obtiene la información de las recetas registradas
        /// </summary>
        /// <param >Sin parametro</param>
        Task<List<ESTADOS_RECETAS>> GetAllESTADOSRECETAS();
        /// <summary>
        /// Registra en la tabla una receta
        /// </summary>
        /// <param>Persona</param>
        string InsEstadosRecetas(ESTADOS_RECETAS estadosRecetas);
        /// <summary>
        /// Actualiza en la tabla una receta
        /// </summary>
        /// <param>Persona</param>
        string UpsEstadosRecetas(ESTADOS_RECETAS estadosRecetas);
        /// <summary>
        /// Elimina un registro de la tabla
        /// </summary>
        /// <param>Persona</param>
        string DelEstadosRecetas(ESTADOS_RECETAS estadosRecetas);
    }
    public class EstadoRecetaRepository
    {
        private readonly ILogger<EstadoRecetaRepository> _logger;
        private readonly Entities _appDbContext;
        public EstadoRecetaRepository(ILogger<EstadoRecetaRepository> logger, Entities appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        public async Task<List<ESTADOS_RECETAS>> GetAllESTADOSRECETAS()
        {
            var result = await _appDbContext.ESTADOS_RECETAS.ToListAsync();

            return result;
        }
        public string InsEstadosRecetas(ESTADOS_RECETAS estadosRecetas)
        {
            string result = string.Empty;
            try
            {
                _appDbContext.ESTADOS_RECETAS.Add(estadosRecetas);
                _appDbContext.SaveChanges();
                result = "Estado de la Receta registrada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public string UpsEstadosRecetas(ESTADOS_RECETAS estadosRecetas)
        {
            string result = string.Empty;
            try
            {
                ESTADOS_RECETAS recetaAnt = _appDbContext.ESTADOS_RECETAS.FirstOrDefault(x => x.ID_ESTADO_RECETA.Equals(estadosRecetas.ID_ESTADO_RECETA));
                recetaAnt.NOMBRE = estadosRecetas.NOMBRE;
                recetaAnt.DESCRIPCION = estadosRecetas.DESCRIPCION;
                _appDbContext.SaveChanges();
                result = "Estado de la Receta actualizada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        public string DelEstadosRecetas(ESTADOS_RECETAS estadosRecetas)
        {
            string result = string.Empty;
            try
            {
                ESTADOS_RECETAS lastReceta = _appDbContext.ESTADOS_RECETAS.FirstOrDefault(x => x.ID_ESTADO_RECETA.Equals(estadosRecetas.ID_ESTADO_RECETA));
                _appDbContext.ESTADOS_RECETAS.Remove(lastReceta);
                _appDbContext.SaveChanges();
                result = "Estado de la Receta eliminada con exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return string.Empty;
        }
    }
}
