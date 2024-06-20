using CRUDSKU.Data;
using CRUDSKU.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CRUDSKU.Controllers
{
    public class SKUController : Controller
    {
        private IConfiguration _configuration;
        public SKUController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<SKU> skus = new();

            DA_SKU daSKU = new DA_SKU(_configuration.GetConnectionString("conexion"));

            DataTable dtSKU = daSKU.Listar();

            foreach (DataRow dr in dtSKU.Rows)
            {
                SKU sku = new();
                sku.Id = (int)dr["IdSKU"];
                sku.Codigo = int.Parse(dr["CodProducto"].ToString()!);
                sku.Descripcion = (string)dr["Descripcion"];
                sku.Nombre = (string)dr["NombreProducto"];

                skus.Add(sku);
            }

            return View(skus);
        }
    }
}
