//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChillDeCojones
{
    using System;
    using System.Collections.Generic;
    
    public partial class CategoriaProducto
    {
        public CategoriaProducto()
        {
            this.Producto = new HashSet<Producto>();
        }
    
        public string NAME { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return NAME;
        }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
