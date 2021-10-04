using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib
{
    public class Major
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int MinSAT { get; set; }
        public override string ToString()
        {
            return $"{Id}, | {Code}, | {Description}, | {MinSAT}";
        }
    }
}
