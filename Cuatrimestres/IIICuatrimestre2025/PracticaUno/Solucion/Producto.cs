using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioPorUnidad { get; set; }
        public string Categoria { get; set; }

        public Producto(int id, string nombre, string descripcion, decimal precio, string categoria)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioPorUnidad = precio;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return $"[{Id}] {Nombre} - ${PrecioPorUnidad:F2} ({Categoria})";
        }
    }
}
