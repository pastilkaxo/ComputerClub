using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Class
{
    public class Procedure
    {

        public Procedure()
        {


        }
        public Procedure(string name, int id)
        {

            Name = name;
            ID = id;
        }
        public string Name { get;  set; }
        public int ID { get;  set; }

        public decimal Price { get; set; }  
        public string Description { get; set; } 

        public TimeSpan Durability { get; set; }
    }
}
