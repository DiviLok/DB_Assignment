using DB_Assignment.Handler;
using DB_Assignment.model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Utility
{
    public class utilityForManytoMany
    {
        public static void AddDetails(Senior_Citizen sc, List<int> serviceIDs)
        {
            using (ServiceContext m2m = new ServiceContext())
            {

                m2m.senior_citizen.Add(sc);

                // Save changes to generate ID
                m2m.SaveChanges();

                ServicesAndSeniorCitizen sc2 = new ServicesAndSeniorCitizen();
                foreach (int serviceID in serviceIDs)
                {
                    sc2.serviceID = serviceID;
                    sc2.seniorCitizenID = sc.ID;
                    m2m.services_and_senior.Add(sc2);
                    m2m.SaveChanges();
                }

            }
        }
        public static void UpdateDetails(int seniorCitizenID, List<int> serviceIDs)
        {
            using (ServiceContext m2m = new ServiceContext())
            {
                ServicesAndSeniorCitizen sc2 = new ServicesAndSeniorCitizen();

                foreach (int serviceID in serviceIDs)
                {
                    try
                    {

                        sc2.serviceID = serviceID;
                        sc2.seniorCitizenID = seniorCitizenID;
                        m2m.services_and_senior.Add(sc2);
                        m2m.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        SqlException innerException = ex.InnerException as SqlException;
                        if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                        {
                            Console.WriteLine("Customer already has the service for :" + serviceID);
                            continue;
                        }
                        throw;
                    }
                }
            }
        }
        internal static List<ServicesByCity> GetListOfServices()
        {
            using (ServiceContext service_context = new ServiceContext())
            {
                var serviceByCity = service_context.services_by_city.ToList();
                return serviceByCity;
            }

        }
    }
}
