using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zoohackaton_api.Models;
using zoohackaton_api.Models.Request;
using zoohackaton_api.Models.Response;
using zoohackaton_api.Services;

namespace zoohackaton_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VoluntarioController : Controller
    {
        private readonly IVoluntarioService voluntarioService;

        public VoluntarioController(IVoluntarioService voluntarioService)
        {
            this.voluntarioService = voluntarioService;
        }

        [HttpPost("registrar")]
        public ActionResult RegistrarVoluntario(RegistrarVoluntarioRequest model)
        {
            try
            {
                MensajeCorrectoResponse response = voluntarioService.RegistrarVoluntario(model);
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
        public ActionResult ActualizarVoluntario(ActualizarVoluntarioRequest model)
        {
            try
            {
                MensajeCorrectoResponse response = voluntarioService.ActualizarVoluntario(model);
                return Ok(response);
            }
            catch (Exception error)
            {
                return BadRequest(new {
                    message = error.ToString()
                });
            }
        }

        [HttpPost("autenticar")]
        public ActionResult AutenticarVoluntario(AutenticarVoluntarioRequest model)
        {
            try
            {
                VoluntarioResponse voluntarioResponse = voluntarioService.AutenticarVoluntario(model);
                
                if(voluntarioResponse.volId == 0)
                {
                    return Ok(new {
                        mensaje = "Usuario o contraseña incorrectos"
                    });
                }
                
                return Ok(voluntarioResponse);
            }
            catch (Exception error)
            {
                return BadRequest(new {
                    message = error.ToString()
                });
            }
        }

        [HttpPost("seleccionarporid")]
        public ActionResult SeleccionarVoluntarioPorId(SeleccionarVoluntarioPorIdRequest model)
        {
            try
            {
                VoluntarioResponse voluntarioResponse = voluntarioService.SeleccionarVoluntarioPorId(model.volId);
                return Ok(voluntarioResponse);
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
