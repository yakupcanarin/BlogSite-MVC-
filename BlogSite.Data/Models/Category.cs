using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Data.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int ID { get; set; }


        [MinLength(3, ErrorMessage = "Category name should be min {0} characters"), MaxLength(100, ErrorMessage = "Category name should be max. {0} characters")]
        [Required]
        public string CategoryName { get; set; }

        public bool isActive { get; set; }

        public virtual ICollection<Article> Article { get; set; }

        public virtual User User { get; set; }
    }
}
