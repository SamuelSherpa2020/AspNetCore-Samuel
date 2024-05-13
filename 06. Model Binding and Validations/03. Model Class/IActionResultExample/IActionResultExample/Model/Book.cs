using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Model
{
    public class Book
    {

        [FromRoute]
        public int? BookId { get; set; }
        public string? Author { get; set; }

        public override string ToString() // This method is overriding to make tostring behave to print the instances of Book class
        {
            return ($"BookId: {BookId} and BookAuthor: {Author}"); 
        }
    }
}
