using System.ComponentModel.DataAnnotations;

namespace StudentDataCRUD.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public bool Subscribed { get; set; }
    }
}
