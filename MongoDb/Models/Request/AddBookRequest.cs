using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MongoDb.Models.Request
{
    public class AddBookRequest
    {
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Publish date is required")]
        public DateTime Published { get; set; }
        [Required(ErrorMessage ="Author is required")]
        public string Author { get; set; }
        public int Quantity { get; set; }
    }
}