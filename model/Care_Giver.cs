using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.model
{
    public class Care_Giver
    {
        [Key]
        public int care_giverID { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int phone_number { get; set; }
        public int age { get; set; }
        [MaxLength(50)]
        public string email_id { get; set; }
        [Required]
        public string shift { get; set; }
        public Boolean driving_license { get; set; }
       public List<Senior_Citizen> elders_under_care { get; set; }
        



    }
}
