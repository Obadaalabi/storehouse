using storehouse_Data;
using storehouse_Domain;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace storehouse_control
{
    public class Book_Controlr 
    {
        public static void Add_Defult()
        {
            String contents = File.ReadAllText("book_defult.json");
            var book_defult = JsonSerializer.Deserialize<List<Book>>(contents);
            using (var context = new Storehouse_DBcontext())
            {
                var books = context.Books.ToList();
                if (books.Count == 0)
                {
                    context.Books.AddRange(book_defult);
                    context.SaveChanges();
                }

            }

        }
        public static void Get_Data()
        {
            Console.Write("enter the id of the book to display : ");
            var id = Console.ReadLine();
            if (int.TryParse(id, out int book_id))
            {
                using (var context = new Storehouse_DBcontext())
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == book_id && b.isDelete==false);
                    if (book==null)
                    {
                        Console.WriteLine("Erorr please enter an id that is in the list");
                        Get_Data();
                    }
                    else
                    {
                      
                            Console.WriteLine("the id : " + book.Id +
                                              "\t the title book : " + book.title +
                                              "\t number of copies : " + book.quantity +
                                              "\t the price : " + book.price);
                        
                    }

                }

            }
            else
            {
                Console.WriteLine("Erorr please enter number");
                Get_Data();
            }


        }
        public static void Numberofbooks()
        {
            using (var context = new Storehouse_DBcontext())
            {
                var books = context.Books.Where(b => b.isDelete == false).ToList();
                Console.WriteLine("number of books = " + books.Count());
            }

        }
        public static void Show_information()
        {
            using (var context = new Storehouse_DBcontext())
            {
                var books = context.Books.Where(b => b.isDelete == false).ToList();
                foreach (var book in books)
                {
                    Console.WriteLine("the id : " + book.Id + "\t the title book : " + book.title + "\t number of copies : " + book.quantity);
                }
                int total_books = books.Sum(b => b.quantity);
                Console.WriteLine("the total number of copies of books : " + total_books);

            }

        }

        public static void Delete()
        {
            Console.Write("enter the id of the book you want to delete : ");
            var id = Console.ReadLine();
            if (int.TryParse(id, out int book_id))
            {
                using (var context = new Storehouse_DBcontext())
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == book_id && b.isDelete == false);
                    if (book==null)
                    {
                        Console.WriteLine("Erorr please enter an id that is in the list");
                        Delete();
                       
                    }
                    else
                    {
                        book.isDelete = true;
                        context.SaveChanges();

                        Console.WriteLine("the book has been successfully deleted");

                    }
                }
            }
        }
        public static void UpDate()
        {
            Console.Write("enter the id of the book you want to update : ");
            var id = Console.ReadLine();
            if (int.TryParse(id, out int book_id))
            {
                Console.Write("enter the new title : ");
                var title = Console.ReadLine();
                Console.Write("enter the id new price : ");
                var price =Convert.ToInt32( Console.ReadLine());

                using (var context = new Storehouse_DBcontext())
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == book_id && b.isDelete == false);
                    if (book == null)
                    {
                        Console.WriteLine("Erorr please enter an id that is in the list");
                        UpDate();

                    }
                    else
                    {
                        book.title=title;
                        book.price=price;
                        context.SaveChanges();

                        Console.WriteLine("the book has been successfully updated");

                    }
                }
            }

        }
      

      

        

      

        
      
    }
}