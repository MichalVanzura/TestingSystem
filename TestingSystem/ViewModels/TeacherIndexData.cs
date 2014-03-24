using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingSystem.Models;

namespace TestingSystem.ViewModels
{
    public class TeacherIndexData
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<StudentGroup> StudentGroups { get; set; }
    }
}