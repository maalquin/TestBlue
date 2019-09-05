using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlueBook.Data.Model
{
    public partial class Category
    {
        [Key]
        public int Id { get; set; }
       
        public string Categoryname { get; set; }
    }
}
