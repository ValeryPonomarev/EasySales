using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model
{
    public partial class Student : Person
    {
        private int studentGroupID;
        private StudentGroup studentGroup;

        public Student() : this(null) { }

        public Student(Guid? key) : this(key, string.Empty, string.Empty) { }

        public Student(Guid? key, string name, string surName) : base(key)
        {
            this.Name = name;
            this.SurName = surName;
        }

        public int StudentGroupID
        {
            get
            {
                return studentGroupID;
            }

            set
            {
                studentGroupID = value;
            }
        }
        
        public StudentGroup StudentGroup
        {
            get
            {
                return studentGroup;
            }

            set
            {
                studentGroup = value;
            }
        }
    }
}
