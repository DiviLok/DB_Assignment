using DB_Assignment.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Handler
{
    public class SeniorCitizenHandler
    {
        public static List<Senior_Citizen> get_all_senior_citizen()
        {
            using (ServiceContext service_context = new ServiceContext())
            {
                var elders_under_care = service_context.senior_citizen.Include(x => x.care_givers).ToList();
                return elders_under_care;
            }
        }
        public void AddSeniorCitizen(Senior_Citizen senior_Citizen)
        {
            using (ServiceContext service_context = new ServiceContext())
            {
                service_context.senior_citizen.Add(senior_Citizen);
                service_context.SaveChanges();
            }

        }

        public Senior_Citizen SearchSeniorCitizenByID(int id)
        {
            Senior_Citizen details;
            using (ServiceContext service_context = new ServiceContext())
            {
                details = service_context.senior_citizen.Find(id);
            }
            return details;
        }
        public void UpdateSeniorCitizen(Senior_Citizen senior_Citizen)
        {
            using (ServiceContext service_context= new ServiceContext())
            {
                var patient = service_context.senior_citizen.Find(senior_Citizen.ID);

                if (patient != null)
                {
                    patient.name = senior_Citizen.name;
                    patient.phone_number = senior_Citizen.phone_number;
                    patient.age = senior_Citizen.age;
                    patient.address = senior_Citizen.address;
                    
                    patient.care_giverID = senior_Citizen.care_giverID;
                    service_context.SaveChanges();
                }
            }
        }
        public void DeleteSeniorCitizen(Senior_Citizen senior_Citizen)
        {
            using (ServiceContext service_context = new ServiceContext())
            {
                service_context.senior_citizen.Remove(senior_Citizen);
                service_context.SaveChanges();
            }
        }
    }
}
