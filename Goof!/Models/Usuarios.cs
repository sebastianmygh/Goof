//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Goof_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.Mascotas = new HashSet<Mascotas>();
        }
    
        public int IdUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Nullable<int> Edad { get; set; }
        public string Ubicacion { get; set; }
        public Nullable<double> Telefono { get; set; }
        public Nullable<int> Estado { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mascotas> Mascotas { get; set; }
    }
}
