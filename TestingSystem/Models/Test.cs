using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Models
{
    public class Test
    {
        public long ID { get; set; }
        public long TestTemplateID { get; set; }
        public double result { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Completed At")]
        public DateTime CompletedAt { get; set; }

        public virtual TestTemplate TestTemplate { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
