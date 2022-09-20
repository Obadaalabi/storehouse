using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storehouse_Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string? name_book { get; set; }

        public string? title { get; set; }

        public int quantity { get; set; }

        public int price { get; set; }

        public bool isDelete { get; set; } = false;


    }
}
