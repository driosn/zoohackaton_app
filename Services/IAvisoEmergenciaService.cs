using System.Collections.Generic;
using zoohackaton_api.Models.Request;
using zoohackaton_api.Models.Response;

namespace zoohackaton_api.Services
{
    public interface IAvisoEmergenciaService
    {
        MensajeCorrectoResponse RegistrarAvisoEmergencia(RegistrarAvisoEmergenciaRequest model);
        MensajeCorrectoResponse ActualizarAvisoEmergencia(ActualizarAvisoEmergenciaRequest model);
        MensajeCorrectoResponse ActualizarEstadoAvisoEmergencia(ActualizarEstadoAvisoEmergenciaRequest model);
        IEnumerable<AvisoEmergenciaResponse> SeleccionarAvisoEmergenciaPorCiudad(SeleccionarAvisoEmergenciaPorCiudadRequest model);        
    }
}