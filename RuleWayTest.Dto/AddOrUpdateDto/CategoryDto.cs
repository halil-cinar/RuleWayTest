using RuleWayTest.Dto.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Dto.AddOrUpdateDto
{
    public class CategoryDto:DtoBase
    {
        public string Name { get; set; }
        public int MinStockQuantity { get; set; }
    }
}
