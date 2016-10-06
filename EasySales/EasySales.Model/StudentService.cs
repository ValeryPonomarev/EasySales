using EasySales.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model
{
    public static class StudentService
    {
        private static IStudentRepository repository;

        static StudentService()
        {
            repository = EFRepositoryFactory.GetRepository<IStudentRepository, Student>();
        }

        public static IList<Student> GetAll()
        {
            return repository.FindAll();
        }

        public static Student Get(Guid key)
        {
            return repository.FindBy(key);
        }

        public static Student Get(int key)
        {
            return repository.FindById(key);
        }

        public static void Save(Student student)
        {
            student.DateEdit = DateTime.Now;
            repository[student.Key] = student;
            repository.Save();
        }

        public static void Delete(Student student)
        {
            repository.Remove(student);
        }
    }
}
