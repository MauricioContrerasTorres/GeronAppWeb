using System.ComponentModel.DataAnnotations;

namespace Macaner.GeronAppWeb.Client.Web.Models
{
    public class RegionViewModel
    {
        public int IdRegion { get; set; }

        [Required(ErrorMessage = "El codigo de región es obligatorio")]
        public string CodigoRegion { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
    }
}
