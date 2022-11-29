using DB_Assignment.model;
using DBAssignment.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Handler
{
    public class CareGiverHandler
    {
        public static List<Care_Giver> GetAllCareGivers()
        {
            using (ServiceContext service_context = new ServiceContext())
            {
                var careGiver = service_context.care_givers.ToList();
                return careGiver;
            }
           
        }
        public void AddCareGiver(Care_Giver careGiver)
        {
            using (ServiceContext sc = new ServiceContext())
            {
                sc.care_givers.Add(careGiver);
                sc.SaveChanges();
            }

        }
        public Care_Giver SearchCareGiverByID(int id)
        {
            Care_Giver details;
            using (ServiceContext service_context = new ServiceContext())
            {
                details = service_context.care_givers.Find(id);
            }
            return details;
        }
        public void UpdateCareGiver(Care_Giver careGiver)
        {
            using (ServiceContext service_context = new ServiceContext())
            {
                var care_giver = service_context.care_givers.Find(careGiver.care_giverID);
                
                if (care_giver != null)
                {
                    care_giver.name = careGiver.name;
                    care_giver.phone_number = careGiver.phone_number;
                    care_giver.age = careGiver.age;
                    care_giver.email_id = careGiver.email_id;
                    care_giver.shift = careGiver.shift;
                    service_context.SaveChanges();
                }
            }
        }
        public void DeleteCareGiver(Care_Giver careGiver)
        {
            using (ServiceContext service_context = new ServiceContext())
            {
                service_context.care_givers.Remove(careGiver);
                service_context.SaveChanges();
            }
        }
    }
}
