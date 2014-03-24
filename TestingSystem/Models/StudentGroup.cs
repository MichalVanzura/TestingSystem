using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Models
{
    public class StudentGroup
    {
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public long TeacherID { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TestTemplate> TestTemplates { get; set; }
    }
}
