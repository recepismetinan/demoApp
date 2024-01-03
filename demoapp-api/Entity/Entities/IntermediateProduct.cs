using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Enums;

namespace Entity.Entities
{
    public class IntermediateProduct
    {
        public string Name { get; set; }
        public IntermediateProductCategory IntermediateProductCategory { get; set; }
        public ProductionStage ProductionStage { get; set; }
        public string StockQuantity { get; set; }
    }
}