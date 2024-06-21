using CRUDSKU.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

		public DataTable Obtener(int id)
		{
			SqlConnection cnn = new(_conexion);
			SqlCommand cmd = cnn.CreateCommand();
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandText = "sp_Obtener";
			cmd.Parameters.AddWithValue("@IdSKU", id);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			return dt;
		}

		public bool Modificar(SKU sku)
		{
			using SqlConnection cnn = new(_conexion);
			using SqlCommand cmd = cnn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "sp_Modify";
			cmd.Parameters.AddWithValue("@IdSKU", sku.Id);
			cmd.Parameters.AddWithValue("@CodProducto", sku.Codigo);
			cmd.Parameters.AddWithValue("@NombreProducto", sku.Nombre);
			cmd.Parameters.AddWithValue("@Descripcion", sku.Descripcion);
			cnn.Open();
			int value = cmd.ExecuteNonQuery();
			cnn.Close();
			return value == 1;
		}

		public bool Eliminar(int id)
		{
			using SqlConnection cnn = new(_conexion);
			using SqlCommand cmd = cnn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "sp_Eliminar";
			cmd.Parameters.AddWithValue("@IdSKU", id);
			cnn.Open();
			int value = cmd.ExecuteNonQuery();
			cnn.Close();
			return value == 1;
		}

		public bool Insertar(SKU sku)
		{
			using SqlConnection cnn = new(_conexion);
			using SqlCommand cmd = cnn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "sp_Guardar";
			cmd.Parameters.AddWithValue("@CodProducto", sku.Codigo);
			cmd.Parameters.AddWithValue("@NombreProducto", sku.Nombre);
			cmd.Parameters.AddWithValue("@Descripcion", sku.Descripcion);
			cnn.Open();
			int value = cmd.ExecuteNonQuery();
			cnn.Close();
			return value == 1;
		}
	}

}
