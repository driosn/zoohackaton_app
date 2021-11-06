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
    public class PersonaController : Controller
    {
        private readonly IPersonaService personaService;

        public PersonaController(IPersonaService personaService)
        {
            this.personaService = personaService;
        }

        [HttpPost("registrar")]
        public ActionResult RegistrarPersona(RegistrarPersonaRequest model)
        {
            try
            {
                MensajeCorrectoResponse personaResponse = personaService.RegistrarPersona(model);
                return Ok(personaResponse);
            }
            catch (Exception error)
            {
                return BadRequest(new {
                    message = error.ToString()
                });
            }
        }

        [HttpPost("actualizar")]
        public ActionResult ActualizarPersona(ActualizarPersonaRequest model)
        {
            try
            {
                MensajeCorrectoResponse personaResponse = personaService.ActualizarPersona(model);
                return Ok(personaResponse);
            }
            catch (Exception error)
            {
                return BadRequest(new {
                    message = error.ToString()
                });
            }
        }

        [HttpPost("autenticar")]
        public ActionResult AutenticarPersona(AutenticarPersonaRequest model)
        {
            try
            {
                PersonaResponse personaResponse = personaService.AutenticarPersona(model);
                
                if (personaResponse.perId == 0)
                {
                    return Ok(new {
                        mensaje = "Usuario o contraseña incorrectos"
                    });    
                }
                return Ok(personaResponse);
            }
            catch (Exception error)
            {
                return BadRequest(new {
                    message = error.ToString()
                });
            }
        }

        [HttpPost("seleccionarporid")]
        public ActionResult SeleccionarPersonaPorId(SeleccionarPersonaPorIdRequest model)
        {
            try
            {
                PersonaResponse personaResponse = personaService.SeleccionarPersonaPorId(model.perId);
                return Ok(personaResponse);
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
