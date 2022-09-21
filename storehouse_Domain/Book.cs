

namespace storehouse_Domain
{
    public class Book
    {
        public int Id { get; set; }
    

        public string? title { get; set; }

        public int quantity { get; set; }

        public int price { get; set; }

        public bool isDelete { get; set; } = false;


    }
}
