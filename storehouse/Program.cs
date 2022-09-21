
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
           
            User_Controlr user_Controlr = new User_Controlr();  

            
                Console.WriteLine("welcome in aplication");
                Console.Write("please enter the name:");
                    var name=Console.ReadLine();
                Console.Write("please enter the password:");
                var password = Console.ReadLine();
                if (user_Controlr.Authentication(name, password))
                {
                    Console.WriteLine("success");
                
                   
                }
                else
                {
                    Console.WriteLine("please check your name and password");
                  
                }

            }

          
        }
    }
}