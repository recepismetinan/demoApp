using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Enums;

namespace Entity.Entities
{
    public class RawMaterial
    {
        public string Name { get; set; }
        public RawMaterialCategory RawMaterialCategory { get; set; }
        public string StockQuantity { get; set; }

    }
}