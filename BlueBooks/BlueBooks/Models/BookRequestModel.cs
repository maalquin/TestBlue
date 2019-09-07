using BlueBook.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBooks.Models
{
    public class BookRequestModel
    {
        //public Book Book { get; set; }

        public int bookId { get; set; }
        public string title { get; set; }
        public int authorID { get; set; }
        public int categoryId { get; set; }

        //public IEnumerable<Author> Authors { get; set; }
    }
}
