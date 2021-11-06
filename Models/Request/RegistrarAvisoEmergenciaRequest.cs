namespace zoohackaton_api.Models.Request
{
    public class RegistrarAvisoEmergenciaRequest
    {
        public int perId { get; set; }
        public float aemLatitud { get; set; }
        public float aemLongitud { get; set; }
        public string aemCiudad { get; set; }
    }
}