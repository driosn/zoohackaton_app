using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using zoohackaton_api.Data;
using zoohackaton_api.Models.Request;
using zoohackaton_api.Models.Response;

namespace zoohackaton_api.Services
{
    public class VoluntarioService : IVoluntarioService
    {
        private readonly ApplicationDbContext context;
        public VoluntarioService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public MensajeCorrectoResponse ActualizarVoluntario(ActualizarVoluntarioRequest model)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarVoluntario";
                cmd.Parameters.Add("@volId", System.Data.SqlDbType.Int).Value = model.volId;
                cmd.Parameters.Add("@volNombre", System.Data.SqlDbType.NVarChar, 100).Value = model.volNombre;
                cmd.Parameters.Add("@volApellido", System.Data.SqlDbType.NVarChar, 100).Value = model.volApellido;
                cmd.Parameters.Add("@volDocIdentidad", System.Data.SqlDbType.NVarChar, 30).Value = model.volDocIdentidad;
                cmd.Parameters.Add("@volCelular", System.Data.SqlDbType.NVarChar, 20).Value = model.volCelular;
                
                var reader = cmd.ExecuteNonQuery();
            
                return new MensajeCorrectoResponse()
                {
                    id = model.volId,
                    mensaje = "Voluntario actualizado correctamente"
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

        public VoluntarioResponse AutenticarVoluntario(AutenticarVoluntarioRequest model)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AutenticarVoluntario";
                cmd.Parameters.Add("@volUsuario", System.Data.SqlDbType.NVarChar, 30).Value = model.volUsuario;
                cmd.Parameters.Add("@volPwd", System.Data.SqlDbType.NVarChar, 30).Value = model.volPwd;
                var reader = cmd.ExecuteReader();

                VoluntarioResponse voluntarioResponse = new VoluntarioResponse();
                
                while (reader.Read())
                {
                    voluntarioResponse = VoluntarioResponse.fromReader(reader);
                }
            
                return voluntarioResponse;
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

        public MensajeCorrectoResponse RegistrarVoluntario(RegistrarVoluntarioRequest model)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "RegistrarVoluntario";
                cmd.Parameters.Add("@volNombre", System.Data.SqlDbType.NVarChar, 100).Value = model.volNombre;
                cmd.Parameters.Add("@volApellido", System.Data.SqlDbType.NVarChar, 100).Value = model.volApellido;
                cmd.Parameters.Add("@volDocIdentidad", System.Data.SqlDbType.NVarChar, 30).Value = model.volDocIdentidad;
                cmd.Parameters.Add("@volPwd", System.Data.SqlDbType.NVarChar, 30).Value = model.volPwd;
                cmd.Parameters.Add("@volUsuario", System.Data.SqlDbType.NVarChar, 30).Value = model.volUsuario;
                cmd.Parameters.Add("@volPais", System.Data.SqlDbType.NVarChar, 30).Value = model.volPais;
                cmd.Parameters.Add("@volCiudad", System.Data.SqlDbType.NVarChar, 30).Value = model.volCiudad;
                cmd.Parameters.Add("@volCelular", System.Data.SqlDbType.NVarChar, 20).Value = model.volCelular;
                var reader = cmd.ExecuteNonQuery();

                return new MensajeCorrectoResponse()
                {
                    id = 0,
                    mensaje = "Voluntario registrado correctamente"
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

        public VoluntarioResponse SeleccionarVoluntarioPorId(int volId)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SeleccionarVoluntarioPorId";
                cmd.Parameters.Add("@volId", System.Data.SqlDbType.Int).Value = volId;
                var reader = cmd.ExecuteReader();

                VoluntarioResponse voluntarioResponse = new VoluntarioResponse();
                
                while (reader.Read())
                {
                    voluntarioResponse = VoluntarioResponse.fromReader(reader);
                }
            
                return voluntarioResponse;
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