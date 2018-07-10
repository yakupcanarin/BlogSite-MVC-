using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Data.Models
{
    public class Article
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="Title")]
        [Required]
        [MaxLength(50,ErrorMessage ="Title must be between 0-50 characters.")]
        public string Title { get; set; }

        [Display(Name ="Body")]
        [Required]
        public string Body { get; set; }

        [Display(Name ="Is Active")]
        public bool Active { get; set; }

        [Display(Name ="Added Date")]
        public DateTime Added_Date { get; set; }

        [Display(Name ="Readed")]
        public int Readed { get; set; }

        public virtual User User { get; set; }

        public string Picture { get; set; }

        public virtual ICollection<Pictures> Pictures { get; set; }

        public virtual Category Category { get; set; }
    }
}
