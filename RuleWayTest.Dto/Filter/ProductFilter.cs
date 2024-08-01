using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Dto.Filter
{
    public class ProductFilter
    {

        public string? Search { get; set; }
       
        public int? StockMin { get; set; }
        public int? StockMax { get; set; }

        
    }
}
