using System.ComponentModel.DataAnnotations;

namespace Macaner.GeronAppWeb.Client.Web.Models
{
    public class UnidadMedidaViewModel
    {
        public int IdUnidadMedida { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
    }
}
