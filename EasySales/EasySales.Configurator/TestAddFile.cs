using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Configurator
{
    public class TestAddFile
    {
        public void AddFile(string pathProject, string pathFile)
        {
            var project = new Microsoft.Build.Evaluation.Project(pathProject);
            project.AddItem("Compile", pathFile);
            project.Save();
        }
    }
}
