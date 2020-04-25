﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LagoMotors.Models
{
    public class FeatureModel
    {
        [Key]
        public int FeatureId { get; set; }
        [Key]
        public int ModelId { get; set; }
        public Feature Feature { get; set; }
      
    }
}
