using Macaner.GeronAppWeb.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Shared.Common
{
    public class RegionEditarRequest
    {
        public int IdRegion { get; set; }

        public RegionDTO DetalleRegion { get; set; }
    }
}
