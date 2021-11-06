using zoohackaton_api.Models.Request;
using zoohackaton_api.Models.Response;

namespace zoohackaton_api.Services
{
    public interface IVoluntarioService
    {
        MensajeCorrectoResponse RegistrarVoluntario(RegistrarVoluntarioRequest model);
        MensajeCorrectoResponse ActualizarVoluntario(ActualizarVoluntarioRequest model);
        VoluntarioResponse AutenticarVoluntario(AutenticarVoluntarioRequest model);
        VoluntarioResponse SeleccionarVoluntarioPorId(int volId);
    }
}