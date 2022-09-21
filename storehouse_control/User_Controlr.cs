using System.Text.Json;
using storehouse_Data;
using storehouse_Domain;


namespace storehouse_control
{
    public class User_Controlr : Controlr
    {
        public  override void Add()
        {
           
        }

        public override void Add_Defult()
        {
            String contents = File.ReadAllText("user_defult.json");
            var user_defult = JsonSerializer.Deserialize<List<User>>(contents);
            using (var context = new Storehouse_DBcontext())
            {
                var user=context.Users.ToList();
                if (user.Count == 0)
                {
                    context.Users.AddRange(user_defult);
                    context.SaveChanges();
                }
               
            }

        }

        public override void Delete()
        {
            
        }


        public override void Get_Data()
        {
           
        }

        public override void UpDate()
        {
           
        }
       
    }
}
