using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.model
{
    public class ServicesAndSeniorCitizen
    {
        public int seniorCitizenID { get; set; }
        public int serviceID { get; set; }
        public Senior_Citizen seniorCitizen { get; set; }
        public ServicesByCity cityServices { get; set; }
    }
}
