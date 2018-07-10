using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Data.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="Role Name: ")]
        [MinLength(3,ErrorMessage ="Role name should be more than 3 characters."),MaxLength(20,ErrorMessage ="Role name should be less than 20 characters.")]
        public string RoleName { get; set; }


    }
}
