using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestingSystem.Models;

namespace TestingSystem.Validation
{
    public class EnsureMinimumElementsAttribute : ValidationAttribute
    {
        private readonly int _minElements;
        public EnsureMinimumElementsAttribute(int minElements)
        {
            _minElements = minElements;
        }

        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count >= _minElements;
            }
            return false;
        }
    }

    public class EnsureNotAllAnswersToDelete : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as List<Answer>;
            if (list != null)
            {
                return !list.All(a => a.deleteThis);
            }
            return false;
        }
    }

    public class EnsureOneCorrectAnswer : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as List<Answer>;
            if (list != null)
            {
                return list.Any(a => a.IsCorrect);
            }
            return false;
        }
    }
}