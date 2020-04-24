using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LagoMotors.Models
{
    public class Model
    {
        public Model()
        {
            ModelFeatures=new Collection<Feature>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }
        public ICollection<Feature> ModelFeatures { get; set; }
    }
}
