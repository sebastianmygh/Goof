using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goof_.Models
{
	public class MascotaViewModel
	{
		
		public string Nombre { get; set; }
		public string Genero { get; set; }
		public string Raza { get; set; }
		public int Edad { get; set; }
		public string ColorPelo { get; set; }
		public string Peso { get; set; }

		public bool Vacunas { get; set; }
		public bool Papeles { get; set; }
		public Nullable<int> LikeCount { get; set; }
		public int IdUsuario { get; set; }
	}
}