using RuleWayTest.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuleWayTest.Entity
{
    [Table("Category")]
    public class CategoryEntity : EntityBase
    {
        public string Name { get; set; }
        public int MinStockQuantity { get; set; }
    }
}