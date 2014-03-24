using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingSystem.Validation;

namespace TestingSystem.Models
{
    public enum QuestionType
    {
        one, multiple
    }

    public class Question
    {
        public long ID { get; set; }

        [Required]
        public string Text { get; set; }

        [Display(Name = "Correct answers")]
        public QuestionType? QuestionType { get; set; }

        public double Points { get; set; }
        public string Explanation { get; set; }

        [Display(Name = "Thematic Area")]
        public long ThematicAreaID { get; set; }

        public virtual ThematicArea ThematicArea { get; set; }

        [EnsureNotAllAnswersToDelete(ErrorMessage = "All answers can not be deleted")]
        [EnsureMinimumElementsAttribute(1, ErrorMessage = "At least one answer is required")]
        [EnsureOneCorrectAnswer(ErrorMessage = "At least one answer must be correct")]
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
