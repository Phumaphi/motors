using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LagoMotors.Models
{
    public class Model
    {
        public Model()
        {
            ModelFeatures=new Collection<FeatureModel>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public int MakeId { get; set; }
        public Make Make { get; set; }
        public ICollection<FeatureModel> ModelFeatures { get; set; }
    }
}
