using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Enums;

namespace Entity.Entities
{
    public class ProductionProcess
    {
        public Product Product { get; set; }
        public ProductionStage ProductionStage { get; set; }
        public decimal Quantity { get; set; }
        public string? Note { get; set; }
    }
}