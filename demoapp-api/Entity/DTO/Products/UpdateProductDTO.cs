using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Entities;

namespace Entity.DTO.Products
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set;}
        public int StockCount { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ICollection<IntermediateProduct> IntermediateProducts { get; set; }
    }
}