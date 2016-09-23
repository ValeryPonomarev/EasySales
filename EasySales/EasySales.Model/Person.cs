using EasySales.Infrastructure;
using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model
{
    public class Person : EntityBase, IEntity
    {
        private string name;
        private string surName;
        private string lastName;
        private DateTime dateBirth;

        private string name2;
        private string surName2;
        private string lastName2;


        public Person() : this(null)
        {
        }

        public Person(Guid? key) : base(key)
        {
            name = String.Empty;
            surName = String.Empty;
            lastName = String.Empty;
            dateBirth = DataHelper.MinSqlDate;
            name2 = String.Empty;
            surName2 = String.Empty;
            lastName2 = String.Empty;
        }

        #region Properties
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string SurName
        {
            get
            {
                return surName;
            }

            set
            {
                surName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public DateTime DateBirth
        {
            get
            {
                return dateBirth;
            }

            set
            {
                dateBirth = value;
            }
        }

        public string Name2
        {
            get
            {
                return name2;
            }

            set
            {
                name2 = value;
            }
        }

        public string SurName2
        {
            get
            {
                return surName2;
            }

            set
            {
                surName2 = value;
            }
        }

        public string LastName2
        {
            get
            {
                return lastName2;
            }

            set
            {
                lastName2 = value;
            }
        }
        #endregion

    }
}
