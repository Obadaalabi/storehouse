
using storehouse_control;
using storehouse_Data;
using storehouse_Domain;
using System.Text.Json;

namespace storehouse
{
    internal class Program
    {
        static void Main(string[] args)
        {

          
            User_Controlr.Add_Defult();
            Book_Controlr.Add_Defult();

            Console.WriteLine("welcome in aplication");
            Console.Write("please enter the name:");
            var name = Console.ReadLine();
            Console.Write("please enter the password:");
            var password = Console.ReadLine();
            if (User_Controlr.Authentication(name, password))
            {
                Console.WriteLine("success");
                Book_Controlr.Numberofbooks();
                bool isopen=true;
                while (isopen)
                {
                    Console.WriteLine("Command List:\n" +
                                       "1- Click (1) to view library information\n" +
                                       "2- Press (2) to display the information of a specific book\n" +
                                       "3- Press (3) to delete a book\n" +
                                       "4- Press (4) to modify the title and price of a book\n" +
                                       "5- Press (5) to exit");

                    Console.Write("Enter a number from the list please    ");
                    var select = Console.ReadLine();

                    switch (select)
                    {
                        case ("1"): Book_Controlr.Show_information();
                            break;
                        case ("2"): Book_Controlr.Get_Data();
                            break;
                        case ("3"): Book_Controlr.Delete();
                            break;
                        case ("4"):
                            break;
                        case ("5"): isopen=false;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("Good-bye");
            }
            else
            {
                Console.WriteLine("please check your name and password");

            }
        }
    }
}