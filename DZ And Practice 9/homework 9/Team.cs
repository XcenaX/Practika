using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_9
{
    public class Team
    {
        public TeamLeader leader { get; set; }
        public Worker worker { get; set; }
        public House house { get; set; }

        public Team(){
            leader = new TeamLeader();
            worker = new Worker();
            house = new House();
         }
    }
}
