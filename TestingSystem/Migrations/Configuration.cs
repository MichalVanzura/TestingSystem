namespace TestingSystem.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using TestingSystem.DAL;
    using TestingSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestingSystem.DAL.TestingSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TestingSystem.DAL.TestingSystemContext context)
        {
            var thematicAreas = new List<ThematicArea>
            {
                new ThematicArea{Name="UNIX"},
                new ThematicArea{Name="Java"},
            };
            thematicAreas.ForEach(ta => context.ThematicAreas.AddOrUpdate(p => p.Name, ta));
            SaveChanges(context);

            var questions = new List<Question>
            {
                new Question{Text = "Operaèní systém UNIX vznikl okolo roku", Points = 2, ThematicAreaID = thematicAreas[0].ID, QuestionType = QuestionType.one},
                new Question{Text = "První verze UNIXu byla vytvoøena v", Points = 2, ThematicAreaID = thematicAreas[0].ID, QuestionType = QuestionType.one},
                new Question{Text = "Pro které z následujících aplikací je vhodný transientní (pomíjivý) druh komunikace?", Points = 2,  ThematicAreaID = thematicAreas[1].ID, QuestionType = QuestionType.multiple},
            };
            questions.ForEach(q => context.Questions.AddOrUpdate(p => p.Text, q));
            SaveChanges(context);

            var answers = new List<Answer>
            {
                new Answer{Text = "1950", IsCorrect = false, 
                    QuestionID = questions.Single(q => q.Text == "Operaèní systém UNIX vznikl okolo roku").ID},
                new Answer{Text = "1960", IsCorrect = false, 
                    QuestionID = questions.Single(q => q.Text == "Operaèní systém UNIX vznikl okolo roku").ID},
                new Answer{Text = "1970", IsCorrect = true, 
                    QuestionID = questions.Single(q => q.Text == "Operaèní systém UNIX vznikl okolo roku").ID},
                new Answer{Text = "1980", IsCorrect = false, 
                    QuestionID = questions.Single(q => q.Text == "Operaèní systém UNIX vznikl okolo roku").ID},
                new Answer{Text = "1990", IsCorrect = false, 
                    QuestionID = questions.Single(q => q.Text == "Operaèní systém UNIX vznikl okolo roku").ID},

                new Answer{Text = "Bell Laboratories", IsCorrect = true, 
                    QuestionID = questions.Single(q => q.Text == "První verze UNIXu byla vytvoøena v").ID},
                new Answer{Text = "University of Berkeley", IsCorrect = false,  
                    QuestionID = questions.Single(q => q.Text == "První verze UNIXu byla vytvoøena v").ID},
                new Answer{Text = "Microsoftu", IsCorrect = false,  
                    QuestionID = questions.Single(q => q.Text == "První verze UNIXu byla vytvoøena v").ID},
                new Answer{Text = "Novellu", IsCorrect = false,  
                    QuestionID = questions.Single(q => q.Text == "První verze UNIXu byla vytvoøena v").ID},
                new Answer{Text = "USL (UNIX System Laboratories)", IsCorrect = false,  
                    QuestionID = questions.Single(q => q.Text == "První verze UNIXu byla vytvoøena v").ID},

                new Answer{Text = "internetový prohlížeè", IsCorrect = true,  
                    QuestionID = questions.Single(q => q.Text == "Pro které z následujících aplikací je vhodný transientní (pomíjivý) druh komunikace?").ID},
                new Answer{Text = "podnikový objednávkový systém", IsCorrect = false,  
                    QuestionID = questions.Single(q => q.Text == "Pro které z následujících aplikací je vhodný transientní (pomíjivý) druh komunikace?").ID},
                new Answer{Text = "aplikace internetového rádia", IsCorrect = true,  
                    QuestionID = questions.Single(q => q.Text == "Pro které z následujících aplikací je vhodný transientní (pomíjivý) druh komunikace?").ID},
                new Answer{Text = "aplikace pro øízení lodní dopravy", IsCorrect = false,  
                    QuestionID = questions.Single(q => q.Text == "Pro které z následujících aplikací je vhodný transientní (pomíjivý) druh komunikace?").ID},
            };
            answers.ForEach(a => context.Answers.AddOrUpdate(p => p.Text, a));
            SaveChanges(context);

            var teachers = new List<Teacher>
            {
                new Teacher{FirstName = "Bronwyn",LastName = "Dumond",BirthDate = DateTime.Parse("2004-11-05"), 
                    StudentGroups = new List<StudentGroup>()},
                new Teacher{FirstName = "Jacqulyn",LastName = "Caughman",BirthDate = DateTime.Parse("2004-06-19"), 
                    StudentGroups = new List<StudentGroup>()},
                new Teacher{FirstName = "Jannet",LastName = "Lasher",BirthDate = DateTime.Parse("2003-03-05"), 
                    StudentGroups = new List<StudentGroup>()},
            };
            teachers.ForEach(s => context.Teachers.AddOrUpdate(p => p.LastName, s));
            SaveChanges(context);

            var studentGroups = new List<StudentGroup>
            {
                new StudentGroup{Name = "Skupina 1", TeacherID = teachers.Single(t => t.LastName == "Dumond").ID},
                new StudentGroup{Name = "Skupina 2", TeacherID = teachers.Single(t => t.LastName == "Dumond").ID},
                new StudentGroup{Name = "Skupina 3", TeacherID = teachers.Single(t => t.LastName == "Caughman").ID},
                new StudentGroup{Name = "Skupina 4", TeacherID = teachers.Single(t => t.LastName == "Lasher").ID},
            };
            studentGroups.ForEach(sg => context.StudentGroups.AddOrUpdate(p => p.Name, sg));
            SaveChanges(context);

            var students = new List<Student>
            {
            new Student{FirstName = "Carson",LastName = "Alexander",BirthDate = DateTime.Parse("2000-09-06"), 
                StudentGroups = new List<StudentGroup>()},
            new Student{FirstName = "Meredith",LastName = "Alonso",BirthDate = DateTime.Parse("2002-09-20"), 
                StudentGroups = new List<StudentGroup>()},
            new Student{FirstName = "Arturo",LastName = "Anand",BirthDate = DateTime.Parse("2003-09-18"), 
                StudentGroups = new List<StudentGroup>()},
            new Student{FirstName = "Gytis",LastName = "Barzdukas",BirthDate = DateTime.Parse("2002-09-10"), 
                StudentGroups = new List<StudentGroup>()},
            new Student{FirstName = "Yan",LastName = "Li",BirthDate = DateTime.Parse("2002-09-28"), 
                StudentGroups = new List<StudentGroup>()},
            new Student{FirstName = "Peggy",LastName = "Justice",BirthDate = DateTime.Parse("2001-09-09"), 
                StudentGroups = new List<StudentGroup>()},
            new Student{FirstName = "Laura",LastName = "Norman",BirthDate = DateTime.Parse("2003-09-03"), 
                StudentGroups = new List<StudentGroup>()},
            new Student{FirstName = "Nino",LastName = "Olivetto",BirthDate = DateTime.Parse("2005-08-25"), 
                StudentGroups = new List<StudentGroup>()},
            new Student{FirstName = "Tillie",LastName = "Critchlow",BirthDate = DateTime.Parse("2001-10-09"), 
                StudentGroups = new List<StudentGroup>()},
            new Student{FirstName = "Adele",LastName = "Bish",BirthDate = DateTime.Parse("2003-12-02"), 
                StudentGroups = new List<StudentGroup>()},
            new Student{FirstName = "Augustus",LastName = "Saxton",BirthDate = DateTime.Parse("2000-02-04"), 
                StudentGroups = new List<StudentGroup>()},
            new Student{FirstName = "Garry",LastName = "Luhman",BirthDate = DateTime.Parse("2002-06-17"), 
                StudentGroups = new List<StudentGroup>()},
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            SaveChanges(context);

            AddOrUpdateStudent(context, "Skupina 1", "Alexander");
            AddOrUpdateStudent(context, "Skupina 4", "Alexander");
            AddOrUpdateStudent(context, "Skupina 1", "Alonso");
            AddOrUpdateStudent(context, "Skupina 2", "Alonso");
            AddOrUpdateStudent(context, "Skupina 1", "Anand");
            AddOrUpdateStudent(context, "Skupina 1", "Barzdukas");
            AddOrUpdateStudent(context, "Skupina 1", "Li");
            AddOrUpdateStudent(context, "Skupina 2", "Li");
            AddOrUpdateStudent(context, "Skupina 3", "Li");
            AddOrUpdateStudent(context, "Skupina 1", "Justice");
            AddOrUpdateStudent(context, "Skupina 2", "Norman");
            AddOrUpdateStudent(context, "Skupina 2", "Olivetto");
            AddOrUpdateStudent(context, "Skupina 2", "Critchlow");
            AddOrUpdateStudent(context, "Skupina 4", "Critchlow");
            AddOrUpdateStudent(context, "Skupina 2", "Bish");
            AddOrUpdateStudent(context, "Skupina 1", "Saxton");
            AddOrUpdateStudent(context, "Skupina 2", "Saxton");
            AddOrUpdateStudent(context, "Skupina 3", "Saxton");
            AddOrUpdateStudent(context, "Skupina 4", "Saxton");
            AddOrUpdateStudent(context, "Skupina 3", "Luhman");

            SaveChanges(context);
        }

        void AddOrUpdateStudent(TestingSystemContext context, string studentGroupName, string studentName)
        {
            var sgs = context.StudentGroups.SingleOrDefault(sg => sg.Name == studentGroupName);
            var sts = sgs.Students.SingleOrDefault(st => st.LastName == studentName);
            if (sts == null)
                sgs.Students.Add(context.Students.Single(sg => sg.LastName == studentName));
        }

        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
