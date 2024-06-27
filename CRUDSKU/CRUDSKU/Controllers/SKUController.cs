using CRUDSKU.Data;
using CRUDSKU.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;


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

		
		public IActionResult Create()
		{
			return View();
		}

		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Codigo,Nombre,Descripcion")] SKU sku)
		{
			if (ModelState.IsValid)
			{
				DA_SKU daSKU = new DA_SKU(_configuration.GetConnectionString("conexion"));
				daSKU.Insertar(sku);

				return RedirectToAction(nameof(Index));
			}
			return View(sku);
		}
		public IActionResult Edit(int id)
		{
			DA_SKU daSKU = new(_configuration.GetConnectionString("conexion"));
			DataTable dt = daSKU.Obtener(id);
			if (dt.Rows.Count == 0)
			{
				return NotFound();
			}

			DataRow dr = dt.Rows[0];
			SKU sku = new SKU
			{
				Id = (int)dr["IdSKU"],
				Codigo = int.Parse(dr["CodProducto"].ToString()!),
				Descripcion = (string)dr["Descripcion"],
				Nombre = (string)dr["NombreProducto"]
			};

			return View(sku);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("Id,Codigo,Nombre,Descripcion")] SKU sku)
		{
			if (id != sku.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				DA_SKU daSKU = new DA_SKU(_configuration.GetConnectionString("conexion"));

				daSKU.Modificar(sku);

				return RedirectToAction(nameof(Index));
			}
			return View(sku);
		}

		
		public IActionResult Delete(int id)
		{
			DA_SKU daSKU = new DA_SKU(_configuration.GetConnectionString("conexion"));
			DataTable dt = daSKU.Obtener(id);
			if (dt.Rows.Count == 0)
			{
				return NotFound();
			}

			DataRow dr = dt.Rows[0];
			SKU sku = new SKU
			{
				Id = (int)dr["IdSKU"],
				Codigo = int.Parse(dr["CodProducto"].ToString()!),
				Descripcion = (string)dr["Descripcion"],
				Nombre = (string)dr["NombreProducto"]
			};

			return View(sku);
		}

		
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			DA_SKU daSKU = new DA_SKU(_configuration.GetConnectionString("conexion"));
			daSKU.Eliminar(id);

			return RedirectToAction(nameof(Index));
		}

        

        
    }
}
    
