using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace zoohackaton_api.Models
{
    public class PersonaResponse
    {
        public int perId { get; set; }
        public string perNombre { get; set; }
        public string perApellido { get; set; }
        public string perDocIdentidad { get; set; }
    
        public string perPais { get; set;}
        public string perCiudad { get; set; }
        public string  perCelular { get; set; }
        public DateTime perFecha { get; set; }
        public string perEstado { get; set; } 
    
        public static PersonaResponse fromReader(SqlDataReader reader)
        {
            return new PersonaResponse()
            {
                perId = Convert.ToInt32(reader["perId"]),
                perNombre = reader["perNombre"].ToString(),
                perApellido = reader["perApellido"].ToString(),
                perDocIdentidad = reader["perDocIdentidad"].ToString(),
                perPais = reader["perPais"].ToString(),
                perCiudad = reader["perCiudad"].ToString(),
                perCelular = reader["perCelular"].ToString(),
                perFecha = Convert.ToDateTime(reader["perFecha"]),
                perEstado = reader["perEstado"].ToString()
            };
        } 
    }
}
