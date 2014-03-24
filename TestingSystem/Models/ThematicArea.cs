using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Models
{
    public class ThematicArea
    {
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public long? ThematicAreaID { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<ThematicArea> SubThematicAreas { get; set; }
    }
}
