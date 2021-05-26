﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Buyer : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public byte Age { get; set; }

        public double Money { get; set; }

        public int TelephoneNumber { get; set; }

        public string Email { get; set; }

        public string Sex { get; set; }
    }
}
