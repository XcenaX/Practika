using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_9
{
    public class TeamLeader : IWorker
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public TeamLeader()
        {
            Name = "";
            Age = 0;
        }
    }
}
