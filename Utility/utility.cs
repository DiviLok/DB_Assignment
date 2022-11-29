using DB_Assignment.Handler;
using DB_Assignment.Utility;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.model
{
    public class utility
    {
        static SeniorCitizenHandler scHandler = new SeniorCitizenHandler();
        static Senior_Citizen sc1 = new Senior_Citizen();
        public static void AddingDetailsOfSC()
        {
            Console.WriteLine("Enter the name of Senior Citizen");
            string name = Console.ReadLine();
            Console.WriteLine("Phone number");
            string phone_number = Console.ReadLine();
            Console.WriteLine("Age");
            string age = Console.ReadLine();                      
            Console.WriteLine("Address");
            string address = Console.ReadLine();
            Console.WriteLine("select the care giver ID from the list below");
            utility2.GetTheListOfCareGivers();
            int careGiverID = Convert.ToInt32(Console.ReadLine());
            sc1.care_giverID= careGiverID;

            sc1.phone_number = Convert.ToInt32(phone_number);
            sc1.age = Convert.ToInt32(age);
            sc1.name = name;
            sc1.address = address;
            Console.WriteLine("what are the services needed choose from the list below");
            Console.WriteLine("Choose from the list of services for SeniorCitizen if more than one seperate them with , ");
            List<ServicesByCity> sbc = utilityForManytoMany.GetListOfServices();
            Console.WriteLine("{0,-15}|{1,-15}|{2,-15}", "Service ID", "Name", "Description");
            Console.WriteLine("----------------------------------------------------------");

            foreach (ServicesByCity service in sbc)
            {
                Console.WriteLine("{0,-15}|{1,-15}|{2,-15}", service.serviceID, service.service_name, service.description);
            }
            string[] userInput = Console.ReadLine().Split(',');
            List<int> serviceIDs = new List<int>(Array.ConvertAll(userInput, arrTemp => Convert.ToInt32(arrTemp)));
            utilityForManytoMany.AddDetails(sc1, serviceIDs);
            
           // scHandler.AddSeniorCitizen(sc1);
            Console.WriteLine("Details Added to the Database");


        }
        public static void UpdateDetailsOfSC()
        {
            ListSeniorCitizens();

            Console.WriteLine("Enter the ID of Senior Citizen which needs update. Choose from Above Ids");


            int ID = Convert.ToInt32(Console.ReadLine());
            var sc_details = scHandler.SearchSeniorCitizenByID(ID);

            Console.WriteLine("Choose an option to update details");
            Console.WriteLine("1. name 2. phone number 3. age 4. care_giver 5. address 6. Services");
            int choice = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the name");
                        sc_details.name = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Enter the phone number");
                        sc_details.phone_number = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 3:
                        Console.WriteLine("Enter Age");
                        sc_details.age = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 4:
                        Console.WriteLine("Enter care_giver ID");
                        sc_details.care_giverID = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 5:
                        Console.WriteLine("Enter address");
                        sc_details.address = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("what are the services needed choose from the list below");
                        Console.WriteLine("Choose from the list of services for SeniorCitizen if more than one seperate them with , ");
                        List<ServicesByCity> sbc = utilityForManytoMany.GetListOfServices();
                        Console.WriteLine("{0,-15}|{1,-15}|{2,-15}", "Service ID", "Name", "Description");
                        Console.WriteLine("----------------------------------------------------------");
                        foreach (ServicesByCity service in sbc)
                        {
                            Console.WriteLine("{0,-15}|{1,-15}|{2,-15}", service.serviceID, service.service_name, service.description);
                        }
                        string[] userInput = Console.ReadLine().Split(',');
                        List<int> serviceIDs = new List<int>(Array.ConvertAll(userInput, arrTemp => Convert.ToInt32(arrTemp)));
                        utilityForManytoMany.UpdateDetails(ID, serviceIDs);
                        break;

                }
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("The ID does not Exist choose different ID" + ID);
                UpdateDetailsOfSC();

            }
            try
            {
                scHandler.UpdateSeniorCitizen(sc_details);
                Console.WriteLine("Update successfull");
            }
            catch (NullReferenceException) { }

        }
        public static void DeleteDetails()
        {
            Console.WriteLine("Enter the ID which needs to be delted");
            int ID = Convert.ToInt32(Console.ReadLine());
            var sc_details = scHandler.SearchSeniorCitizenByID(ID);
            scHandler.DeleteSeniorCitizen(sc_details);
            Console.WriteLine("Delete Successfull");

        }

        internal static void ListSeniorCitizens()
        {
            Console.WriteLine("### List of senior citizens availing our services ###");
            List<Senior_Citizen> sc2 = SeniorCitizenHandler.get_all_senior_citizen();
            Console.WriteLine("{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}", "ID", "Name", "Address", "Phone Number", "CareGiverID", "Age");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var sc3 in sc2)
            {
                Console.WriteLine("{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}", sc3.ID, sc3.name, sc3.address, sc3.phone_number, sc3.care_giverID, sc3.age);
            }
        }
    }
}
