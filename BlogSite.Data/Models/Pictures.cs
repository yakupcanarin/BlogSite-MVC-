using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Data.Models
{
    [Table("Pictures")]
    public class Pictures
    {
        [Key]
        public int ID { get; set; }
        
        public string Picture { get; set; }

        public virtual Article Article { get; set; }
    }
}
