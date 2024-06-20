namespace CRUDSKU.Models
{
    public class SKU
    {
        public int Id { get; set; }

        public int Codigo { get; set; }

        public string Nombre {  get; set; } = string.Empty;

        public string Descripcion {  get; set; } = string.Empty;
    }
}
