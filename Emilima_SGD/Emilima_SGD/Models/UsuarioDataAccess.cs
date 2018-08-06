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
    }
}
