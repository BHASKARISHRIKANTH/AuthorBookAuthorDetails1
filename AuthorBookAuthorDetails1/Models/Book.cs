using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorBookAuthorDetails1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime DateOfRelease { get; set; }

        public Author? Author { get; set; }

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
    }
}
