using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.model
{
    public class ServicesByCity
    {
        [Key]
        public int serviceID { get; set; }
        public string service_name { get; set; }
        public string description { get; set; }
        public List<ServicesAndSeniorCitizen> serviceAndSeniorCitizen { get; set; }

    }
}
