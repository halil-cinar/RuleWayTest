using RuleWayTest.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Entity
{
    [Table("Product")]
    public class ProductEntity:EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int StockQuantity { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public CategoryEntity Category { get; set; }

        [NotMapped]
        public bool Live
        {
            get
            {
                return CategoryId != null && Category?.MinStockQuantity < StockQuantity;

            }
        }
    }
}
