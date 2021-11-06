namespace zoohackaton_api.Models.Request
{
    public class ActualizarVoluntarioRequest
    {
        public int volId { get; set; }
        public string volNombre { get; set; }
        public string volApellido { get; set; }
        public string volDocIdentidad { get; set; }
        public string volCelular { get; set; }
    }
}