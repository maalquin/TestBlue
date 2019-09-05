using BlueBook.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBooks.Models
{
    public class BookResponseModel
    {
        public int BookId { get; set; }
        
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public AuthorResponseModel author { get; set; }
        public CategoryResponseModel category { get; set; }

    }
    public class CategoryResponseModel
    {
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }
    }
}
