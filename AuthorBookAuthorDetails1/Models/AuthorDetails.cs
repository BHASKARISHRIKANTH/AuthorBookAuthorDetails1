namespace AuthorBookAuthorDetails1.Models
{
    public class AuthorDetails
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Author? Author { get; set; }
    }
}
