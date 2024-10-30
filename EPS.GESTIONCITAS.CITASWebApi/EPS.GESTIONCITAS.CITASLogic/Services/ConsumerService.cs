using EPS.GESTIONCITAS.CITASLogic.Services.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.CITASLogic.Services
{
    public interface IConsumerService
    {
        /// <summary>
        /// Envia una petición POST a la URL indicada
        /// </summary>
        /// <param name="url">Dirección web a enviar la petición</param>
        /// <param name="data">Información a enviar</param>
        /// <param name="errorMessage">Mensaje por defecto cuando no se tiene respuesta del servidor</param>
        Task<ServiceResult<string>> SendPostAsync(string url, object data, string errorMessage = "");
    }
    public class ConsumerService : IConsumerService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ConsumerService> _logger;

        public ConsumerService(HttpClient httpClient,
                               ILogger<ConsumerService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            _httpClient.Timeout = TimeSpan.FromSeconds(60);
        }

        public async Task<ServiceResult<string>> SendPostAsync(string url, object data, string errorMessage = "El proceso no fue exitoso")
        {
            ServiceResult<string> result = new ServiceResult<string>();

            try
            {
                var opcionesJSON = new JsonSerializerOptions() { WriteIndented = true };
                string postString = JsonSerializer.Serialize(data, opcionesJSON);

                HttpResponseMessage dataResponse = await _httpClient.PostAsync(url,
                                                                                new StringContent(postString, Encoding.Default, "application/json"));

                if (!dataResponse.IsSuccessStatusCode)
                {
                    result.Errors.Add(errorMessage);
                }

                result.Extras = await dataResponse.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException hrex)
            {
                _logger.LogError(hrex.Message);
                result.Errors.Add($"No es posible enviar los datos de la petición");
            }
            catch (OperationCanceledException ocex)
            {
                _logger.LogError(ocex.Message);
                result.Errors.Add($"No es posible contactar con servidor");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.Errors.Add($"Ocurrió un error en la petición");
            }
            finally
            {
                result.MarkAsSuccessIfNoErrors();
            }

            return result;
        }
    }
}
