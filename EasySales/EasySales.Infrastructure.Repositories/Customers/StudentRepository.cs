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
    class StudentRepository : EFSqlCeRepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository() : base() {
            Database.SetInitializer<StudentRepository>(new CreateDatabaseIfNotExists<StudentRepository>());
        }

        public DbSet<EasySales.Model.Entities.StudentGroup> StudentGroups { get; set; }
    }
}
