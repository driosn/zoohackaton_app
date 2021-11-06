using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zoohackaton_api.Data;
using zoohackaton_api.Models;
using zoohackaton_api.Models.Request;
using zoohackaton_api.Models.Response;
using zoohackaton_api.Services;

namespace zoohackaton_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AvisoEmergenciaController : Controller
    {
        private readonly IAvisoEmergenciaService avisoEmergenciaService;
        public AvisoEmergenciaController(ApplicationDbContext context, IAvisoEmergenciaService avisoEmergenciaService)
        {
            this.avisoEmergenciaService = avisoEmergenciaService;
        }

        [HttpPost("registrar")]
        public ActionResult RegistrarAvisoEmergencia(RegistrarAvisoEmergenciaRequest model)
        {
            try
            {
                MensajeCorrectoResponse response = avisoEmergenciaService.RegistrarAvisoEmergencia(model);
                return Ok(response);
            }
            catch (Exception error)
            {
                return BadRequest(new {
                    message = error.ToString()
                });
            }
        }
        [HttpPost("actualizar")]
        public ActionResult ActualizarAvisoEmergencia(ActualizarAvisoEmergenciaRequest model)
        {
            try
            {
                MensajeCorrectoResponse response = avisoEmergenciaService.ActualizarAvisoEmergencia(model);
                return Ok(response);
            }
            catch (Exception error)
            {
                return BadRequest(new {
                    message = error.ToString()
                });
            }
        }
        [HttpPost("actualizarestado")]
        public ActionResult ActualizarEstadoAvisoEmergencia(ActualizarEstadoAvisoEmergenciaRequest model)
        {
            try
            {
                MensajeCorrectoResponse response = avisoEmergenciaService.ActualizarEstadoAvisoEmergencia(model);
                return Ok(response);
            }
            catch (Exception error)
            {
                return BadRequest(new {
                    message = error.ToString()
                });
            }
        }
        [HttpPost("seleccionarporciudad")]
        public ActionResult SeleccionarAvisoEmergenciaPorCiudad(SeleccionarAvisoEmergenciaPorCiudadRequest model)
        {
            try
            {
                IEnumerable<AvisoEmergenciaResponse> avisosEmergencia = avisoEmergenciaService.SeleccionarAvisoEmergenciaPorCiudad(model);
                return Ok(avisosEmergencia);
            }
            catch (Exception error)
            {
                return BadRequest(new {
                    message = error.ToString()
                });
            }
        }
    }
}
