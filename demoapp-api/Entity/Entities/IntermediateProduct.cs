using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Entity.Enums;

namespace Entity.Entities
{
    public class IntermediateProduct : BaseEntity
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public IntermediateProductType IntermediateProductType { get; set; } // ana sınıfı temsil ediyor (demir, tahta gibi)
        public decimal Quantity { get; set; }
    }
}