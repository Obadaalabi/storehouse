
using storehouse_Data;
using storehouse_Domain;
using System.Text.Json;

namespace storehouse_control
{
    public class User_Controlr 
    {
        public static void Add_Defult()
        {
            String contents = File.ReadAllText("user_defult.json");
            var user_defult = JsonSerializer.Deserialize<List<User>>(contents);
            using (var context = new Storehouse_DBcontext())
            {
                var user = context.Users.ToList();
                if (user.Count == 0)
                {
                    context.Users.AddRange(user_defult);
                    context.SaveChanges();
                }

            }
        }

        public static bool Authentication(string name,string password)
        {
            using (var context = new Storehouse_DBcontext())
            {
                var user = context.Users.FirstOrDefault(u => u.name_user == name && u.pass_word == password);
              
                if (user!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }         
        }

    
     
        public static void Add()
        {

        }

        public static void Delete()
        {
            
        }


        public static void Get_Data()
        {
           
        }

        public static void UpDate()
        {
           
        }
       
    }
}
