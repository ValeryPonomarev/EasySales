using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.UI
{
    public abstract class ObjectViewModel<T> : EditableViewModel<T> where T: EntityBase
    {


    }
}
