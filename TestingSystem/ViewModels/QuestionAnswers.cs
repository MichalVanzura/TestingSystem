using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingSystem.Models;

namespace TestingSystem.ViewModels
{
    public class QuestionAnswers
    {
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}