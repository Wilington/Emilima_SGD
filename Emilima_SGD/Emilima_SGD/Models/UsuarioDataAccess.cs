using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Emilima_SGD.Models
{
    public class UsuarioDataAccess
    {
        string connection = "Data Source = DESKTOP-5L1PK86; Initial Catalog=DB_EMILIMA_SGD;User id=sa;Password=Wili0394;";

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            try
            {
                List<Usuario> ltsusuario = new List<Usuario>();
                using (SqlConnection con = new SqlConnection(connection))
                {
                    SqlCommand cmd = new SqlCommand("Listar_Usuarios", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Usuario usuarios = new Usuario();
                        usuarios.CodUsua = rdr["US_USUA"].ToString();
                        usuarios.us_nombre = rdr["US_NOMB"].ToString();
                        usuarios.us_mail = rdr["US_MAIL"].ToString();

                        ltsusuario.Add(usuarios);
                    }
                    con.Close();
                }
                return ltsusuario;
            }
            catch
            {
                throw;
            }

        }

        public string NuevoUsuario(Usuario usuario)
        {
            try
            {
                string ltsusuario = "Error";

                using (SqlConnection con = new SqlConnection(connection))
                {
                    SqlCommand cmd = new SqlCommand("Usuario_Nuevo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usuario", usuario.CodUsua);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.us_nombre);
                    cmd.Parameters.AddWithValue("@Mail", usuario.us_mail);
                    cmd.Parameters.AddWithValue("@Contra", usuario.us_contra);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ltsusuario = rdr["Result"].ToString();
                    }
                    con.Close();
                }
                return ltsusuario;
            }
            catch
            {
                throw;
            }

        }

        public string EditarUsuario(Usuario usuario)
        {
            try
            {
                string ltsusuario = "Error";

                using (SqlConnection con = new SqlConnection(connection))
                {
                    SqlCommand cmd = new SqlCommand("Usuario_Edita", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usuario", usuario.CodUsua);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.us_nombre);
                    cmd.Parameters.AddWithValue("@Mail", usuario.us_mail);
                    cmd.Parameters.AddWithValue("@Contra", usuario.us_contra);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ltsusuario = rdr["Result"].ToString();
                    }
                    con.Close();
                }
                return ltsusuario;
            }
            catch
            {
                throw;
            }

        }

        public string EliminarUsuario(string usuario)
        {

            try
            {
                string ltsusuario = "Error";

                using (SqlConnection con = new SqlConnection(connection))
                {
                    SqlCommand cmd = new SqlCommand("Usuario_Elimina", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usuario", usuario);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ltsusuario = rdr["Result"].ToString();
                    }
                    con.Close();
                }
                return ltsusuario;
            }
            catch
            {
                throw;
            }

        }

        public string ValidaUsuario(Login login)
        {
            try
            {
                string ltsusuario = "Error";

                using (SqlConnection con = new SqlConnection(connection))
                {
                    SqlCommand cmd = new SqlCommand("Usuario_Valida", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usuario", login.us_usuario);
                    cmd.Parameters.AddWithValue("@Contra", login.us_contra);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ltsusuario = rdr["Result"].ToString();
                    }
                    con.Close();
                }
                return ltsusuario;
            }
            catch
            {
                throw;
            }

        }
    }
}
