using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplication2.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public int SubgenreId { get; set; }
        public List<Subgerne> Subgenres { get; set; }

    }
}