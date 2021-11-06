using System;
using Microsoft.Data.SqlClient;

namespace zoohackaton_api.Models.Response
{
    public class AvisoEmergenciaResponse
    {
        public int aemId { get; set; }
        public int perId { get; set; }
        public double aemLatitud { get; set; }
        public double  aemLongitud { get; set; }
        public string aemCiudad { get; set; }
        public DateTime aemFecha { get; set; }
        public string aemEstado { get; set; }

        public static AvisoEmergenciaResponse fromReader(SqlDataReader reader)
        {
            return new AvisoEmergenciaResponse()
            {
                aemId = Convert.ToInt32(reader["aemId"]),
                perId = Convert.ToInt32(reader["perId"]),
                aemLatitud = Convert.ToDouble(reader["aemLatitud"]),
                aemLongitud = Convert.ToDouble(reader["aemLongitud"]),
                aemCiudad = reader["aemCiudad"].ToString(),
                aemFecha = Convert.ToDateTime(reader["aemFecha"]),
                aemEstado = reader["aemEstado"].ToString()
            };
        }
    }
}