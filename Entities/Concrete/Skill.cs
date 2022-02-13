﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string SkillName { get; set; }
        public int SkillLevel { get; set; }
    }
}
