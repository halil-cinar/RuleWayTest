using RuleWayTest.Dto.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Dto.ListDto
{
    public class ProductListDto:DtoBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public int CategoryId { get; set; }
        public int StockQuantity { get; set; }
        public string CategoryName { get; set; }
        public bool Live { get; set; }

        //public CategoryListDto Category { get; set; }
    }
}
