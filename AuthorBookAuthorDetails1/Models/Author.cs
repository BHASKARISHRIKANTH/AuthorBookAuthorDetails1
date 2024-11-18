using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorBookAuthorDetails1.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public AuthorDetails? AuthorDetails { get; set; }

        public List<Book>? Books { get; set; }
        [ForeignKey("AuthorDetails")]
        public int? AuthorDetailsId { get; set; }
    }
}
