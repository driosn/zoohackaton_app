namespace zoohackaton_api.Models.Request
{
    public class RegistrarPersonaRequest
    {
        public string perNombre { get; set; }
        public string perApellido { get; set; }
        public string perDocIdentidad { get; set; }
        public string perPwd { get; set; }
        public string perUsuario { get; set; }
        public string perPais { get; set; }
        public string perCiudad { get; set; }
        public string perCelular { get; set; }
    }
}