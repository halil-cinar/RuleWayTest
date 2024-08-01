using RuleWayTest.Dto.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Dto.AddOrUpdateDto
{
    public class ProductDto:DtoBase
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int StockQuantity { get; set; }

        

    }
}
