//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace restaurante.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class producto
    {
        public producto()
        {
            this.detalle_orden = new HashSet<detalle_orden>();
        }
    
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public double precio { get; set; }
    
        public virtual ICollection<detalle_orden> detalle_orden { get; set; }
    }
}
