using storehouse_Data;
using storehouse_Domain;
using System.Text.Json;

namespace storehouse_control
{
    public class Book_Controlr : Controlr
    {
     

        public override void Add()
        {
          
        }

        public override void Add_Defult()
        {
            String contents = File.ReadAllText("book_defult.json");
            var book_defult = JsonSerializer.Deserialize<List<Book>>(contents);
            using (var context = new Storehouse_DBcontext())
            {
                var user = context.Books.ToList();
                if (user.Count == 0)
                {
                    context.Books.AddRange(book_defult);
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