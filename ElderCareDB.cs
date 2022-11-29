using DB_Assignment.Handler;
using DB_Assignment.model;
using DB_Assignment.Utility;
using System.Collections.Immutable;

namespace DB_Assignment
{
    public class ElderCareDB
    {
        static Senior_Citizen sc1 = new Senior_Citizen();
        static SeniorCitizenHandler serviceHandler = new SeniorCitizenHandler();

        public static void Main(string[] args)
        {
            try
            {
                string runAgain = "y";
                while (runAgain == "y")
                {
                    Console.Clear();
                    Console.WriteLine("### Elder Services Application ###\n");
                    Console.WriteLine("# What would you like to do?\n");
                    Console.WriteLine(" 1. Update senior citizen info. \n 2. Update care giver info \n");
                    Console.WriteLine(" Type a number from the options above \n");

                    int c = Convert.ToInt32(Console.ReadLine());
                    switch (c)
                    {
                        case 1:
                            SeniorCitizen();
                            break;
                        case 2:
                            CareGiver();
                            break;

                    }

                    Console.WriteLine("\n## Would you like to start over?");
                    Console.WriteLine("Type 'y' to continue, any other key to exit");
                    runAgain = Console.ReadLine();
                }
            } catch (FormatException)
            {
                Console.WriteLine("There was an issue with an entry. Restarting flow.");
                Console.ReadLine();
                Main(args);
            }
        }
        public static void SeniorCitizen()
        {
            Console.Clear();
            Console.WriteLine("## Senior Citizen Services ###\n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine(" 1. List all senior citizens\n 2. Add new senior citizen\n 3. Update existing record \n 4. Delete a record\n");
            Console.WriteLine(" Type a number from the options above \n");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    utility.ListSeniorCitizens();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("## Enter senior citizen info to add to database");
                    utility.AddingDetailsOfSC();
                    break;
                case 3:
                    utility.UpdateDetailsOfSC();
                    break;
                case 4:
                    utility.DeleteDetails();
                    break;
            }

            using ServiceContext myElderDBContext = new ServiceContext();
        }
        public static void CareGiver()
        {
            Console.Clear();
            Console.WriteLine("## Care giver Services ###\n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine(" 1. List all care givers\n 2. Add new care giver\n 3. Update existing record \n 4. Delete a record\n");
            Console.WriteLine(" Type a number from the options above \n");
            
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("### List of care givers providing our services ###");
                    utility2.GetTheListOfCareGivers();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("## Enter the care giver details to add to our database");
                    utility2.AddingDetailsOfCG();
                    break;

                case 3:
                    utility2.UpdateDetailsOfCG();
                    break;
                case 4:
                    utility2.DeleteDetails();
                    break;
            }

        }

    }
}
