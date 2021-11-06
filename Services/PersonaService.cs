using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using zoohackaton_api.Data;
using zoohackaton_api.Models;
using zoohackaton_api.Models.Request;
using zoohackaton_api.Models.Response;

namespace zoohackaton_api.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly ApplicationDbContext context;

        public PersonaService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public MensajeCorrectoResponse ActualizarPersona(ActualizarPersonaRequest model)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarPersona";
                cmd.Parameters.Add("@perId", System.Data.SqlDbType.Int).Value = model.perId;
                cmd.Parameters.Add("@perNombre", System.Data.SqlDbType.NVarChar, 100).Value = model.perNombre;
                cmd.Parameters.Add("@perApellido", System.Data.SqlDbType.NVarChar, 100).Value = model.perApellido;
                cmd.Parameters.Add("@perDocIdentidad", System.Data.SqlDbType.NVarChar, 30).Value = model.perDocIdentidad;
                cmd.Parameters.Add("@perCelular", System.Data.SqlDbType.NVarChar, 20).Value = model.perCelular;
                
                var reader = cmd.ExecuteNonQuery();
            
                return new MensajeCorrectoResponse()
                {
                    id = model.perId,
                    mensaje = "Persona actualizada correctamente"
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

        public PersonaResponse AutenticarPersona(AutenticarPersonaRequest model)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AutenticarPersona";
                cmd.Parameters.Add("@perUsuario", System.Data.SqlDbType.NVarChar, 30).Value = model.perUsuario;
                cmd.Parameters.Add("@perPwd", System.Data.SqlDbType.NVarChar, 30).Value = model.perPwd;
                var reader = cmd.ExecuteReader();

                PersonaResponse personaResponse = new PersonaResponse();
                
                while (reader.Read())
                {
                    Console.WriteLine(reader);
                    personaResponse = PersonaResponse.fromReader(reader);
                }
            
                return personaResponse;
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

        public MensajeCorrectoResponse RegistrarPersona(RegistrarPersonaRequest model)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "RegistrarPersona";
                cmd.Parameters.Add("@perNombre", System.Data.SqlDbType.NVarChar, 100).Value = model.perNombre;
                cmd.Parameters.Add("@perApellido", System.Data.SqlDbType.NVarChar, 100).Value = model.perApellido;
                cmd.Parameters.Add("@perDocIdentidad", System.Data.SqlDbType.NVarChar, 30).Value = model.perDocIdentidad;
                cmd.Parameters.Add("@perPwd", System.Data.SqlDbType.NVarChar, 30).Value = model.perPwd;
                cmd.Parameters.Add("@perUsuario", System.Data.SqlDbType.NVarChar, 30).Value = model.perUsuario;
                cmd.Parameters.Add("@perPais", System.Data.SqlDbType.NVarChar, 30).Value = model.perPais;
                cmd.Parameters.Add("@perCiudad", System.Data.SqlDbType.NVarChar, 30).Value = model.perCiudad;
                cmd.Parameters.Add("@perCelular", System.Data.SqlDbType.NVarChar, 20).Value = model.perCelular;
                var reader = cmd.ExecuteNonQuery();

                return new MensajeCorrectoResponse()
                {
                    id = 0,
                    mensaje = "Persona registrada correctamente"
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

        public PersonaResponse SeleccionarPersonaPorId(int PerId)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SeleccionarPersonaPorId";
                cmd.Parameters.Add("@perId", System.Data.SqlDbType.Int).Value = PerId;
                var reader = cmd.ExecuteReader();

                PersonaResponse personaResponse = new PersonaResponse();
                
                while (reader.Read())
                {
                    personaResponse = PersonaResponse.fromReader(reader);
                }
            
                return personaResponse;
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