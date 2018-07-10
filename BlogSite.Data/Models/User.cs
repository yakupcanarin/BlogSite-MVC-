using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Data.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100, ErrorMessage = "Name and Surname should be less than 100 characters.")]
        [Display(Name ="Name_Surname")]
        public string Name_Surname { get; set; }

        [Display(Name ="Email")]
        [Required]
        [RegularExpression(@"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z",ErrorMessage ="This is an invalid email address.")]
        public string Email { get; set; }

        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [Required]
        [MinLength(8,ErrorMessage ="Your password length can be min. 8 characters."),MaxLength(16,ErrorMessage ="Your password length can be max. 16 character")]
        public string Password { get; set; }

        [Display(Name ="SignUp_Date")]
        public DateTime SignUp_Date { get; set; }

        [Display(Name ="Status")]
        public bool Status { get; set; }

        public virtual Role Role { get; set; }
    }
}
