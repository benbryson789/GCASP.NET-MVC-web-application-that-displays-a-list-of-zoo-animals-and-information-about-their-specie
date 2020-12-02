using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment7a.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public Specie Specie { get; set; }
    }

    public class Specie
    {
        public string Name { get; set; }
        public string Ref { get; set; }
    }

    public class Legend
    {
        public string Weight { get; set; }
    }

    public class Response
    {
        public bool Success { get; set; }
        public int Count { get; set; }
        public IEnumerable<Animal> Results { get; set; }
        public Legend Legend { get; set; }
    }

    
}
