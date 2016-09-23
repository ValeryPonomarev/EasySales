using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.DomainBase
{
    public interface IEntity
    {
        Guid Key { get; }
        DateTime DateCreate { get; }
        DateTime DateEdit { get; set; }
    }
}
