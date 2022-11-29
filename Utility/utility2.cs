using DB_Assignment.Handler;
using DB_Assignment.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Utility
{
    public class utility2
    {
        static CareGiverHandler cgHandler = new CareGiverHandler();
        static Care_Giver cg1 = new Care_Giver();
        public static void AddingDetailsOfCG()
        {
            /*Console.WriteLine("Enter the ID of Senior Citizen");
            string ID = Console.ReadLine();*/
            Console.WriteLine("Enter the name of CareGiver");
            string name = Console.ReadLine();
            Console.WriteLine("Phone number");
            string phone_number = Console.ReadLine();
            Console.WriteLine("Age");
            string age = Console.ReadLine();
            Console.WriteLine("what are the shift");
            string shift = Console.ReadLine();
            Console.WriteLine("email_id");
            string email_id = Console.ReadLine();
            Console.WriteLine("Does Care Giver has driving licence say 'yes' or 'no'");
            string drivingLicense = Console.ReadLine();
            //sc1.ID = Convert.ToInt32(ID);
            cg1.phone_number = Convert.ToInt32(phone_number);
            cg1.age = Convert.ToInt32(age);
            cg1.name = name;
            cg1.shift = shift;
            cg1.email_id = email_id;
            if (drivingLicense == "yes")
            {
                cg1.driving_license = true;

            }
            else
            {
                cg1.driving_license = false;
            }
            cgHandler.AddCareGiver(cg1);
            Console.WriteLine("Details Added to the Database");

        }
        public static void UpdateDetailsOfCG()
        {
            GetTheListOfCareGivers();

            Console.WriteLine("Enter the ID of CareGiver need to update. Choose from the above list");
            int ID = Convert.ToInt32(Console.ReadLine());
            var cg_details = cgHandler.SearchCareGiverByID(ID);

            Console.WriteLine("Choose an option to update details");
            Console.WriteLine("1. name 2. phone number 3. age 4. shift 5. email_id 6. Driving license ");
            int choice = Convert.ToInt32(Console.ReadLine());
            try {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the name");
                        cg_details.name = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Enter the phone number");
                        cg_details.phone_number = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 3:
                        Console.WriteLine("Enter Age");
                        cg_details.age = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 4:
                        Console.WriteLine("Enter shift");
                        cg_details.shift = Console.ReadLine();
                        break;

                    case 5:
                        Console.WriteLine("Enter EmailID");
                        cg_details.email_id = Console.ReadLine();
                        break;

                    case 6:
                        Console.WriteLine("Enter driving license status (yes or no)");
                        var status = Console.ReadLine();
                        if (status == "yes")
                        {
                            cg_details.driving_license = true;
                        }
                        else
                        {
                            cg_details.driving_license = false;
                        }
                    break;


                } 
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("The ID does not Exist choose different ID" + ID);
                UpdateDetailsOfCG();

            }

            try
            {
                cgHandler.UpdateCareGiver(cg_details);
                Console.WriteLine("Update successfull");
            }
            catch (NullReferenceException) { }

        }
        public static void DeleteDetails()
        {
            Console.WriteLine("Enter the ID which shift to be delted");
            int ID = Convert.ToInt32(Console.ReadLine());
            var cg_details = cgHandler.SearchCareGiverByID(ID);
            cgHandler.DeleteCareGiver(cg_details);
            Console.WriteLine("Delete Successfull");
        }

        internal static void GetTheListOfCareGivers()
        {
            List<Care_Giver> sc2 = CareGiverHandler.GetAllCareGivers();
            Console.WriteLine("{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}", "CareGiverID", "Name", "Shift", "Age", "EmailID", "Driving License", "PhoneNumber");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var sc3 in sc2)
            {
                Console.WriteLine("{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}", sc3.care_giverID, sc3.name, sc3.shift, sc3.age, sc3.email_id, sc3.driving_license, sc3.phone_number);
            }
        }
    }
}
