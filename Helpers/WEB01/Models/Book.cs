using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEB01.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("Author_ID")]
        public virtual Author Author { get; set; }
    }
}
