using LoggerApp;
using Microsoft.Extensions.Logging;
using storehouse_Data;
using storehouse_Domain;
using System.Text.Json;

namespace storehouse_control
{
    public class User_Controlr 
    {
    

        public static void Add_Defult()
        {
             Logger logger = new Logger();
            String contents = File.ReadAllText("user_defult.json");
            var user_defult = JsonSerializer.Deserialize<List<User>>(contents);
            using (var context = new Storehouse_DBcontext())
            {
                var user = context.Users?.ToList();
                if (user?.Count == 0)
                {
                    context.Users?.AddRange(user_defult!);
                    context.SaveChanges();
                   
                    logger.LogInformation("The default data for the users has been added successfully");
                }
                
            }
        }

        public static bool Authentication(string name,string password)
        {
            Logger logger = new Logger();
            using (var context = new Storehouse_DBcontext())
            {
                var user = context.Users?.FirstOrDefault(u => u.name_user == name
                                                         && u.pass_word == password);
              
                if (user!=null)
                {
                  
                    logger.LogInformation("Successfully logged in with the name : "
                                           +name + "  and password : "+password);
                    return true;
                }
                else
                {
                    logger.LogErorr("The user is trying to login using a username : "
                                    + name + "  and a password : " + password);
                    return false;
                }
            }         
        }
       
    }
}
