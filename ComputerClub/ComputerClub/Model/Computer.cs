using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Class
{
    public class Computer
    {

        public Computer()
        {
        }
        public Computer(int id,string type)
        {
            Id = id;
            Type = type;

        }

        public int Id { get;  set; }
        public string Type { get;  set; }

        public string Processor { get;  set; }

        public string Videocard { get;  set; }

        public string RAM { get;  set; }

        public string CompDesc { get;  set; }

        public int Count { get;  set; }
    }
}
