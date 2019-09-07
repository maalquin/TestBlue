using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBooks.Models
{
    public class CategoryModelRequest
    {
        public int? categoryID { get; set; }
    }
    public class CategoryCreateModel
    {
        public int? categoryID { get; set; }
        public string categoryName { get; set; }
    }
}
