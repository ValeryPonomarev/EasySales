using EasySales.Model;
using EasySales.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.Repositories.Customers
{
    class StudentRepository : EFSqlCeRepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository() : base() { }
    }
}
