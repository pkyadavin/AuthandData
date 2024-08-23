using System.ComponentModel.DataAnnotations;

namespace Auth.Model.Entity
{
    public class Item
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public int ParentCategoryId { get; set; }
    }

    public class ItemBom
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public int ParentCategoryId { get; set; }
        public List<ItemBom>? SubItems { get; set; }
    }
}
