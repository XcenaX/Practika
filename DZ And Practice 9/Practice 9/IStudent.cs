using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9
{
   public interface IStudent
    {
      string Name { get; set; }
      string FullName { get; set; }
        int[] Grades;
        String GetName();
        String GetFullName();
        Double GetAvgGrade();
    }
}
