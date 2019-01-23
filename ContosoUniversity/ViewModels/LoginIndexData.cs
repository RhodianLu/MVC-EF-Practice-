using ContosoUniversity.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.ViewModels
{
    public class LoginIndexData
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Person> Persons { get; set; }


        [Required]
        [DisplayName("name")]
        public string name { get; set; }

        [Required]
        [DisplayName("password")]
        public string password { get; set; }
    }
}