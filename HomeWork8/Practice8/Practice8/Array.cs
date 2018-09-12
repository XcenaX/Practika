using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8
{
    class MyArray
    {
       private int[] array;

        MyArray(int size)
        {
            array = new int[size];
            for(int i = 0; i < array.Length; i++)
            {
                Random random = new Random(i);
                array[i] = random.Next(0,10);
            }
        }

        public int[] GetArray()
        {
            return array;
        }

        public int GetElement(int index)
        {
            return array[index];
        }

        public static MyArray operator <(MyArray array1, MyArray array2)
        {
            int countOfFirstArray = 0, countOfSecondArray = 0;

            for(int i = 0; i < array1.GetArray().Length; i++)
            {
                countOfFirstArray += array1.GetElement(i);
            }
            for (int i = 0; i < array2.GetArray().Length; i++)
            {
                countOfSecondArray += array2.GetElement(i);
            }
            if (countOfFirstArray > countOfSecondArray) return array2;
            return array1;
        }

        public static MyArray operator >(MyArray array1, MyArray array2)
        {
            int countOfFirstArray = 0, countOfSecondArray = 0;

            for (int i = 0; i < array1.GetArray().Length; i++)
            {
                countOfFirstArray += array1.GetElement(i);
            }
            for (int i = 0; i < array2.GetArray().Length; i++)
            {
                countOfSecondArray += array2.GetElement(i);
            }
            if (countOfFirstArray > countOfSecondArray) return array1;
            return array2;
        }

    }
}
