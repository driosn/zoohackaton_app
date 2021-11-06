namespace zoohackaton_api.Models.Request
{
    public class RegistrarVoluntarioRequest
    {
        public string volNombre { get; set; }
        public string volApellido { get; set; }
        public string volDocIdentidad { get; set; }
        public string volPwd { get; set; }
        public string volUsuario { get; set; }
        public string volPais { get; set; }
        public string volCiudad { get; set; }
        public string volCelular { get; set; }
    }
}