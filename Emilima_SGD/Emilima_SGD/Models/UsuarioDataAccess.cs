using Microsoft.Extensions.Configuration;
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
        private string connection = "";

        public UsuarioDataAccess(IConfiguration configuration)
        {           
            //connection = "Data Source = .; Initial Catalog=DB_EMILIMA_SGD;Integrated Security=true;";
            connection = configuration.GetConnectionString("DefaultConnection").ToString();
        }
        
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
                    cmd.Parameters.AddWithValue("@Area", usuario.ar_codi);

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
        #endregion

        #region CRUD_TR_Usuario_Area
        public string NuevoUsuario_Area(Usuario usuario)
        {
            try
            {
                string ltsusuario = "Error";

                using (SqlConnection con = new SqlConnection(connection))
                {
                    SqlCommand cmd = new SqlCommand("TR_UsuarioArea_Nuevo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usuario", usuario.CodUsua);
                    cmd.Parameters.AddWithValue("@Area", usuario.ar_codi);

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

        public string EliminaUsuario_Area(Usuario usuario)
        {
            try
            {
                string ltsusuario = "Error";

                using (SqlConnection con = new SqlConnection(connection))
                {
                    SqlCommand cmd = new SqlCommand("TR_UsuarioArea_Elimina", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usuario", usuario.CodUsua);
                    cmd.Parameters.AddWithValue("@Area", usuario.ar_codi);

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

        public IEnumerable<Usuario> ListaUsuario_Area(Usuario usuario)
        {
            try
            {
                List<Usuario> ltsusuario_area = new List<Usuario>();

                using (SqlConnection con = new SqlConnection(connection))
                {
                    SqlCommand cmd = new SqlCommand("TR_UsuarioArea_Lista", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usuario", usuario.CodUsua);
                    cmd.Parameters.AddWithValue("@Area", usuario.ar_codi);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Usuario usuarios = new Usuario();
                        usuarios.CodUsua = rdr["US_USUA"].ToString();
                        usuarios.us_nombre = rdr["US_NOMB"].ToString();
                        usuarios.us_mail = rdr["US_MAIL"].ToString();
                        usuarios.ar_nomb = rdr["AR_NOMB"].ToString();
                        usuarios.ar_codi = Convert.ToInt32(rdr["AR_CODI"]);

                        ltsusuario_area.Add(usuarios);
                    }
                    con.Close();
                }
                return ltsusuario_area;
            }
            catch
            {
                throw;
            }

        }
        #endregion

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
