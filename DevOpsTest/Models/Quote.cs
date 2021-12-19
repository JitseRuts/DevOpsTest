using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsTest.Models
{
    class Quote : IComparable<Quote>
    {
        public string Name { get; set; }
        public Quote()
        {
        }
        public Quote(string name)
        {
            Name = name;
        }

        public int CompareTo(Quote other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
