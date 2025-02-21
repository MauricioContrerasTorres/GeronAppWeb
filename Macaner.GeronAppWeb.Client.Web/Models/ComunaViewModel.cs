using Macaner.GeronAppWeb.Service.Interface;
using Macaner.GeronAppWeb.Shared.DTO;
using System.ComponentModel.DataAnnotations;

namespace Macaner.GeronAppWeb.Client.Web.Models
{
    public class ComunaViewModel
    {
        private readonly IRegionService _regionService;
        public int IdComuna { get; set; }

        [Required(ErrorMessage ="La región es obligatoria")]
        public int IdRegion { get; set; }
        public List<DropDownDTO> ListaRegiones { get; set; } = new List<DropDownDTO>();

        [Required(ErrorMessage = "El código de la comuna es obligatoria")]
        public string CodigoComuna { get; set; }

        [Required(ErrorMessage = "El nombre de comuna es obligatoria")]
        public string Nombre { get; set; }


        public ComunaViewModel(IRegionService regionService)
        {
            _regionService = regionService;
            //ListaRegiones = new List<RegionDTO.DropDown>();
        }

        public async Task InitializeAsync()
        {
            await CreateSelectRegiones();
        }

        private async Task CreateSelectRegiones()
        {
            
                ListaRegiones = await _regionService.GetDropDownAsync();
            
            
        }
    }
}
