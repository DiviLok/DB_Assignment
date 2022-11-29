using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.model
{
    public class Authentication
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; } 

    }
}
