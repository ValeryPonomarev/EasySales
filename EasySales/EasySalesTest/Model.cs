using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySalesTest
{
    public class Work
    {
        public int Id { get; set; }
        public DateTime Begin { get; set; }
        public DateTime? End { get; set; }
        public WorkProject Project { get; set; }
    }

    public class WorkProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
    }
}
