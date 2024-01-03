using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class ProductionProcess
    {
        public string? Note { get; set; }
        public bool IsApproved { get; set; }
        public int ProductCount { get; set; }
    }
}