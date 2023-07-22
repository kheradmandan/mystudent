namespace Students.Models
{
    public class StudentNomreViewModel
    {
        public int Id { get; set; }
    
        public string UserName { get; set; }

     
        public string Name { get; set; } = default!;

   
        public int Age { get; set; }


        public string NationalCode { get; set; } = default!;

        public string? Nomre { get; set; } = default!;
        public int CourseId { get; set; }

    }
}
