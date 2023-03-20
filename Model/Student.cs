using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFileApi.Model
{
    public class Student
    {
        [Key]
        [Column("Student_ID")]
        public int ID { get; set;}

        public int RollNo { get; set;}

        [Required(ErrorMessage ="EnrollmentNo cannot be empty")]
        public string EnrollmentNo { get; set;}

        [Required(ErrorMessage ="Name cannot be empty")]
        public string Name { get; set;}

        [Required(ErrorMessage ="Branch cannot be empty")]
        public string Branch { get; set;}

        [Required(ErrorMessage ="University cannot be empty")]
        public string University { get; set;}
    }
}