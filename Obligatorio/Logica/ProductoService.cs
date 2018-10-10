using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    
    public class ProductoService
    {
        private List<Producto> listaProductos;

        public ProductoService()
        {
            this.listaProductos = new List<Producto>();
        }

        public void AltaProducto(String nombre)
        {
            if (!ExisteProducto(nombre))
            {
                Producto producto = new Producto(nombre);
                this.listaProductos.Add(producto);
            }
        }

        public Boolean ExisteProducto(String nombre)
        {
            Boolean esta = false;
            for (int i = 0; i < this.listaProductos.Count() && !esta; i++)
            {
                if (nombre.Equals(this.listaProductos.ElementAt(i).nombre))
                {
                    esta = true;
                }
            }
            return esta;
        }

        public void ModificarProducto()
        {

        }
    }
}
