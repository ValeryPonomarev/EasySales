using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.UI
{
    public class EntityAction
    {
        private string name;
        private DelegateCommand command;

        public EntityAction(string name, DelegateCommand command)
        {
            this.name = name;
            this.command = command;
        }

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

        public DelegateCommand Command
        {
            get
            {
                return command;
            }

            set
            {
                command = value;
            }
        }

    }
}
