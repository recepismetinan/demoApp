using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Enums;

namespace Entity.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public ProductTypes ProductTypes { get; set; }
        

    }
}