using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models
{
   public  class Film:Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Double ImDb { get; set; }
        public string ImagePath { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
