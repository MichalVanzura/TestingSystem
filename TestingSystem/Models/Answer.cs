using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models
{
    public class Answer
    {
        public long ID { get; set; }

        public long QuestionID { get; set; }

        public string Text { get; set; }

        [Display(Name = "Correct answer")]
        public bool IsCorrect { get; set; }

        [NotMapped]
        public bool deleteThis { get; set; }

        public virtual Question Question { get; set; }
    }
}
