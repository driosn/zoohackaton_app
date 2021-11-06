using System;

namespace zoohackaton_api.Models.Request
{
    public class ActualizarAvisoEmergenciaRequest
    {
        public int aemId { get; set; }
        public float aemLatitud { get; set; }
        public float aemLongitud { get; set; }
    }
}