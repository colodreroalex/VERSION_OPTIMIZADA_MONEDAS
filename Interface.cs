using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RepasoConversorMonetario
{
    public static class Interface
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("0.- Exit");
            Console.WriteLine("1.- Change Values");
            Console.WriteLine("2.- Convert Money");
            Console.WriteLine("");
            Console.Write("Choose an option...");
        }      
        
        public static int MainMenuOption(byte maxOp)
        {
            int op = 0;  
            bool wasCorrect = false;

            do
            {

                MainMenu();

                try
                {
                    op = ReadOption(maxOp); 
                    wasCorrect = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (!wasCorrect); 

            return op;
        }

        public static void ConvertMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("0.- Exit");
            Console.WriteLine("1.- Eur --> Dollar");
            Console.WriteLine("2.- Dollar --> Eur");
            Console.WriteLine("");
            Console.Write("Choose an option...");
        }

        public static int ConvertMenuOption(byte maxOp)
        {
            int op = 0;
            bool wasCorrect = false;


            do
            {
                ConvertMenu();

                try
                {
                    op = ReadOption(maxOp);
                    wasCorrect = true;
                }
                catch (Exception)
                {

                    throw new Exception("Error: Option invalid on convert menu...");
                }
            } while (!wasCorrect);
            

            return op ;
        }

        public static int ReadOption(byte maxOp)
        {
            int option = 0;
            option = Convert.ToInt32(Console.ReadLine());

            if (option < 0 || option > maxOp) 
            {
                throw new Exception("Error: Min/Max value was not correct..."); 
            }

            return option;
        }

        
        internal static double DollValue()
        {
            double doll = 0;
            Console.WriteLine("Introduce a value for a doll:   ");
            doll = Convert.ToDouble(Console.ReadLine());
            return doll;
        }

        internal static double EurValue()
        {
            double eur = 0;
            Console.WriteLine("Introduce a value for a eur:   ");

            eur = Convert.ToDouble(Console.ReadLine());

            return eur;
        }

        internal static string ExitConfirmation()
        {
            string a; 
            Console.WriteLine("Are u sure to save changes on file..? Y/N");
            a = Console.ReadLine();

            return a; 
        }

        internal static double UserValue()
        {
            double user = 0;    
            Console.WriteLine("Imput the value that u want to convert...");
            user = Convert.ToDouble(Console.ReadLine());
            return user;
        }

        internal static void ShowResults(double result)
        {
            Console.WriteLine("The value converted is " + result);
            Console.WriteLine("Please touch ENTER for continue...");
            Console.ReadLine();
        }
    }
}
