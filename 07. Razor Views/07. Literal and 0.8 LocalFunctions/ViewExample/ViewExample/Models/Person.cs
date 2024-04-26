namespace ViewExample.Models
{
    public class Person
    {
        public string? Name { get; set; }
        public DateTime? DOB { get; set; }
        public Gender? PersonGender { get; set; }
    }


    public enum Gender
    {
        Male,
        Female,
        Others
    }
}
