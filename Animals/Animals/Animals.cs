using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
        public int id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string content { get; set; }
    }

    public class Animals
    {
        public int totalResults { get; set; }
        public int startIndex { get; set; }
        public int itemsPerPage { get; set; }
        public List<Animal> results { get; set; }
    }
}
