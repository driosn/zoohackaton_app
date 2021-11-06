using System;
using Microsoft.Data.SqlClient;

namespace zoohackaton_api.Models.Response
{
    public class VoluntarioResponse
    {
        public int volId { get; set; }
        public string volNombre { get; set; }
        public string volApellido { get; set; }
        public string volDocIdentidad { get; set; }
    
        public string volPais { get; set;}
        public string volCiudad { get; set; }
        public string  volCelular { get; set; }
        public DateTime volFecha { get; set; }
        public string volEstado { get; set; } 
    
        public static VoluntarioResponse fromReader(SqlDataReader reader)
        {
            return new VoluntarioResponse()
            {
                volId = Convert.ToInt32(reader["volId"]),
                volNombre = reader["volNombre"].ToString(),
                volApellido = reader["volApellido"].ToString(),
                volDocIdentidad = reader["volDocIdentidad"].ToString(),
                volPais = reader["volPais"].ToString(),
                volCiudad = reader["volCiudad"].ToString(),
                volCelular = reader["volCelular"].ToString(),
                volFecha = Convert.ToDateTime(reader["volFecha"]),
                volEstado = reader["volEstado"].ToString()
            };
        }
    }
}