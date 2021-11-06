using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zoohackaton_api.Models;
using zoohackaton_api.Models.Request;
using zoohackaton_api.Models.Response;

namespace zoohackaton_api.Services
{
    public interface IPersonaService
    {
        MensajeCorrectoResponse RegistrarPersona(RegistrarPersonaRequest model);
        MensajeCorrectoResponse ActualizarPersona(ActualizarPersonaRequest model);
        PersonaResponse AutenticarPersona(AutenticarPersonaRequest model);
        PersonaResponse SeleccionarPersonaPorId(int PerId); 
    }
}
