using RuleWayTest.Dto.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Dto.ListDto
{
    public class CategoryListDto:DtoBase
    {
        public string Name { get; set; }
        public int MinStockQuantity { get; set; }
    }
}
