namespace zoohackaton_api.Models.Request
{
    public class ActualizarPersonaRequest
    {
        public int perId { get; set; }
        public string perNombre { get; set; }
        public string perApellido { get; set; }
        public string perDocIdentidad { get; set; }
        public string perCelular { get; set; }
    }
}