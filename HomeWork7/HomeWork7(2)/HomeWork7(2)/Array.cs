using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7_2_
{
    class Indexator
    {
        private double[] array = new double[2];
        public double this[int index]
        {
            get { return Math.Sqrt(array[index]); }
            set { array[index] = (value * value); }
        }
    }
}
