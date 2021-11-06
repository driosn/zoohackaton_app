using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using zoohackaton_api.Data;
using zoohackaton_api.Models.Request;
using zoohackaton_api.Models.Response;

namespace zoohackaton_api.Services
{
    public class AvisoEmergenciaService : IAvisoEmergenciaService
    {
        private readonly ApplicationDbContext context;
        public AvisoEmergenciaService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public MensajeCorrectoResponse ActualizarAvisoEmergencia(ActualizarAvisoEmergenciaRequest model)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarAvisoEmergencia";
                cmd.Parameters.Add("@aemId", System.Data.SqlDbType.Int).Value = model.aemId;
                cmd.Parameters.Add("@aemLatitud", System.Data.SqlDbType.NVarChar, 100).Value = model.aemLatitud;
                cmd.Parameters.Add("@aemLongitud", System.Data.SqlDbType.NVarChar, 100).Value = model.aemLongitud;
                
                var reader = cmd.ExecuteNonQuery();
            
                return new MensajeCorrectoResponse()
                {
                    id = model.aemId,
                    mensaje = "Aviso emergencia actualizado correctamente"
                };
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                conn.Close();
            }
        }

        public MensajeCorrectoResponse ActualizarEstadoAvisoEmergencia(ActualizarEstadoAvisoEmergenciaRequest model)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarEstadoAvisoEmergencia";
                cmd.Parameters.Add("@aemId", System.Data.SqlDbType.Int).Value = model.aemId;
                cmd.Parameters.Add("@aemEstado", System.Data.SqlDbType.NVarChar, 100).Value = model.aemEstado;
                
                var reader = cmd.ExecuteNonQuery();
            
                return new MensajeCorrectoResponse()
                {
                    id = model.aemId,
                    mensaje = "Estado aviso emergencia actualizado correctamente"
                };
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                conn.Close();
            }
        }

        public MensajeCorrectoResponse RegistrarAvisoEmergencia(RegistrarAvisoEmergenciaRequest model)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "RegistrarAvisoEmergencia";
                cmd.Parameters.Add("@perId", System.Data.SqlDbType.Int).Value = model.perId;
                cmd.Parameters.Add("@aemLatitud", System.Data.SqlDbType.NVarChar, 100).Value = model.aemLatitud;
                cmd.Parameters.Add("@aemLongitud", System.Data.SqlDbType.NVarChar, 100).Value = model.aemLongitud;
                cmd.Parameters.Add("@aemCiudad", System.Data.SqlDbType.NVarChar, 30).Value = model.aemCiudad;
                
                var reader = cmd.ExecuteNonQuery();
            
                return new MensajeCorrectoResponse()
                {
                    id = model.perId,
                    mensaje = "Aviso emergencia registrado correctamente"
                };
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                conn.Close();
            }
        }

        public IEnumerable<AvisoEmergenciaResponse> SeleccionarAvisoEmergenciaPorCiudad(SeleccionarAvisoEmergenciaPorCiudadRequest model)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SeleccionarAvisoEmergenciaPorCiudad";
                cmd.Parameters.Add("@aemCiudad", System.Data.SqlDbType.NVarChar, 30).Value = model.aemCiudad;
                
                var reader = cmd.ExecuteReader();
            
                List<AvisoEmergenciaResponse> avisosEmergencia = new List<AvisoEmergenciaResponse>();

                while (reader.Read())
                {
                    avisosEmergencia.Add(AvisoEmergenciaResponse.fromReader(reader));
                }

                return avisosEmergencia;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}