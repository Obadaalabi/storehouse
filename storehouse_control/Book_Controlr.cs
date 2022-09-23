using LoggerApp;
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
            Logger logger = new Logger();
            String contents = File.ReadAllText("book_defult.json");
            var book_defult = JsonSerializer.Deserialize<List<Book>>(contents);
            using (var context = new Storehouse_DBcontext())
            {
                var books = context.Books?.ToList();
                if (books?.Count == 0)
                {
                    context.Books?.AddRange(book_defult!);
                    context.SaveChanges();
                    logger.LogInformation("The default data for the books has been added successfully");
                }

            }

        }
        public static void Get_Data()
        {
            Logger logger = new Logger();
            Console.Write("enter the id of the book to display : ");
            var id = Console.ReadLine();
            if (int.TryParse(id, out int book_id))
            {
                using (var context = new Storehouse_DBcontext())
                {
                    var book = context.Books?.FirstOrDefault(b => b.Id == book_id 
                                                             && b.isDelete==false);
                    if (book==null)
                    {
                        logger.LogWarning("The user has entered a book ID : "+id+
                                          "  Not available to display");
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
                logger.LogErorr("The user entered a book ID with the wrong pattern : " + id +
                                "  when trying to view a book");
                Console.WriteLine("Erorr please enter number");
                Get_Data();
            }


        }
        public static void Numberofbooks()
        {
           
            using (var context = new Storehouse_DBcontext())
            {
                var books = context.Books?.Where(b => b.isDelete == false).ToList();
                Console.WriteLine("number of books = " + books?.Count());
               
            }

        }
        public static void Show_information()
        {
            using (var context = new Storehouse_DBcontext())
            {
                var books = context.Books?.Where(b => b.isDelete == false).ToList();
                foreach (var book in books)
                {
                    Console.WriteLine("the id : " + book.Id +"\t the title book : " + book.title +
                                      "\t number of copies : " + book.quantity);
                }
                int total_books = books.Sum(b => b.quantity);
                Console.WriteLine("the total number of copies of books : " + total_books);

            }

        }

        public static void Delete()
        {
            Logger logger = new Logger();
            Console.Write("enter the id of the book you want to delete : ");
            var id = Console.ReadLine();
            if (int.TryParse(id, out int book_id))
            {
                using (var context = new Storehouse_DBcontext())
                {
                    var book = context.Books?.FirstOrDefault(b => b.Id == book_id
                                                             && b.isDelete == false);
                    if (book==null)
                    {
                        logger.LogWarning("The user has entered a book ID : " + id +
                                          "  Not available for deletion");
                        Console.WriteLine("Erorr please enter an id that is in the list");
                        Delete();
                       
                    }
                    else
                    {
                        book.isDelete = true;
                        context.SaveChanges();
                        logger.LogInformation("User deleted book ID : " + id + "  Successfully");
                        Console.WriteLine("the book has been successfully deleted");

                    }
                }
            }
            else
            {
                logger.LogErorr("The user entered a book ID with the wrong pattern : " + id + 
                                "  when trying to delete a book");
                Console.WriteLine("Erorr please enter number");
                Delete();

            }
        }
        public static void UpDate()
        {
            Logger logger = new Logger();
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
                    var book = context.Books?.FirstOrDefault(b => b.Id == book_id
                                                             && b.isDelete == false);
                    if (book == null)
                    {
                        logger.LogWarning("The user has entered a book ID : " +id +
                                          "  Not available for update");
                        Console.WriteLine("Erorr please enter an id that is in the list");
                        UpDate();

                    }
                    else
                    {
                        var old_title = book.title;
                        var old_price=book.price;
                        book.title=title;
                        book.price=price;
                        context.SaveChanges();
                        logger.LogInformation("The book updated by the user and ID : "+id+
                                              "  and its old address : "+old_title+
                                              "  and its old price: "+old_price+
                                              "  Successfully");
                        Console.WriteLine("the book has been successfully updated");

                    }
                }
            }
            else
            {
                logger.LogErorr("The user entered a book ID with the wrong pattern : " + id +
                                "  when trying to update a book");
                Console.WriteLine("Erorr please enter number");
                UpDate();
            }

        }
      

      

        

      

        
      
    }
}