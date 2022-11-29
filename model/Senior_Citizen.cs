using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.model
{
    public class Senior_Citizen
    {
        public int ID { get; set; }
        public string name { get; set; }
        [Required]
        public int phone_number { get; set; }
        [Required]
        public int age { get; set; }
        public string address { get; set; }
       
        public int care_giverID { get; set; }
        public Care_Giver care_givers { get; set; }
        public List<ServicesAndSeniorCitizen> serviceAndSeniorCitizen { get; set; }

        // public List<Care_Giver> care_givers { get; set; } = new List<Care_Giver>();
    }
}
