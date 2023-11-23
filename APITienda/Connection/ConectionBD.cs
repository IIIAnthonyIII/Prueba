using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
using APITienda.Resource;

namespace APITienda.Connection
{
  public class ConectionBD
  {
    public static string cadenaConexion = "Data Source=DESKTOP-AQ0CDDK\\SQLEXPRESS;Initial Catalog=StoreBD;User ID=loginnew;Password=123";
    public static DataTable Listar (string nombreProcedimiento, List<Parametro> parametros = null)
    {
      SqlConnection conexion = new SqlConnection(cadenaConexion);
      try
      {
        conexion.Open();
        SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        if (parametros != null)
        {
          foreach (var parametro in parametros)
          {
            cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
          }
        }
        DataTable tabla = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(tabla);
        return tabla;
      } catch (Exception ex)
      {
        return null;
      } finally
      {
        conexion.Close();
      }
    }
    public static bool Ejecutar (string nombreProcedimiento, List<Parametro> parametros = null)
    {
      SqlConnection conexion = new SqlConnection(cadenaConexion);

      try
      {
        conexion.Open();
        SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        if (parametros != null)
        {
          foreach (var parametro in parametros)
          {
            cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
          }
        }

        int i = cmd.ExecuteNonQuery();

        return (i > 0) ? true : false;
      } catch (Exception ex)
      {
        return false;
      } finally
      {
        conexion.Close();
      }
    }
  }
}
