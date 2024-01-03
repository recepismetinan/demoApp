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
        public IntermediateProductTypes IntermediateProductTypes { get; set; }
        public string StockQuantity { get; set; }
    }
}