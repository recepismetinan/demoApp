using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Entity.Enums;

namespace Entity.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? Note { get; set; }
        public int StockCount { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ICollection<IntermediateProduct> IntermediateProducts { get; set; }
        
    }
}