using System.Data;
using System.Data.SqlClient;

namespace CRUDSKU.Data
{
    public class DA_SKU
    {
        private string _conexion;

        public DA_SKU(string conexion)
        {
            _conexion = conexion;
        }

        public DataTable Listar()
        {
            SqlConnection cnn = new(_conexion);
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_listar";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public DataTable Obtener()
        {
            SqlConnection cnn = new(_conexion);
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_listar";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
    }
}
