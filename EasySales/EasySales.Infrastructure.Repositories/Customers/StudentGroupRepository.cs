using EasySales.Model;
using EasySales.Model.Entities;
using EasySales.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.Repositories
{
    public class StudentGroupRepository : EFSqlCeRepositoryBase<StudentGroup>, IStudentGroupRepository
    {
        public StudentGroupRepository() : base() {
            Database.SetInitializer<StudentGroupRepository>(new CreateDatabaseIfNotExists<StudentGroupRepository>());
        }
    }
}
