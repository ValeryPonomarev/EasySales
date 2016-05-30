using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySalesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            WorkContext context = new WorkContext();
            //context.Projects.Add(new WorkProject() { Data = DateTime.Now.ToShortDateString(), Id = 1, Name = "Project 1" });
            //context.Projects.Add(new WorkProject() { Data = DateTime.Now.ToShortDateString(), Id = 1, Name = "Project 1" });
            //context.Projects.Add(new WorkProject() { Data = DateTime.Now.ToShortDateString(), Id = 1, Name = "Project 1" });
            //context.SaveChanges();
            foreach (WorkProject project in context.Projects)
            {
                Console.WriteLine(string.Format("Id = {0}, Name = {1}, Data = {2}", project.Id, project.Name, project.Data));
            }

            Console.ReadLine();
        }
    }
}
