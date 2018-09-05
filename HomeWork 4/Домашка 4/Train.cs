using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2 
{
    struct Vagon
    {
        private int number;
        private int countOfPeople;

        public void SetNumber(int number)
        {
            this.number = number;
        }

        public int GetNumber()
        {
            return number;
        }

        public void SetCountOfPeople( int countOfPeople)
        {
            this.countOfPeople = countOfPeople;
        }

        public int GetCountOfPeople()
        {
            return countOfPeople;
        }
    }

    class Train
    {
       private Vagon[] vagon;
        double speed;
        string name;

        public Train()
        {
            vagon = new Vagon[0];
            name = "";
            
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetSpeed(double speed)
        {
            this.speed = speed;
        }

        public double GetSpeed()
        {
            return speed;
        }


        public Object GetVagon(int number)
        {
            Object obj = number;
            for (int i = 0; i < vagon.Length; i++)
            {
                if (obj == vagon.GetValue(i))
                {
                    return vagon.GetValue(i);
                }
            }
            return false;
        }
        
        public void SetNumberOfVagon(int oldNumberOfVagon, int newNumberOfVagon)
        {
            Object obj = oldNumberOfVagon;
            for(int i = 0; i < vagon.Length; i++)
            {
                if(obj == vagon.GetValue(i))
                {
                    vagon.SetValue(newNumberOfVagon,i);
                    return;
                }
            }
            Console.WriteLine("Такого номера вагона не найдено!!");
        }

        public void AddVagon(int number, int countOfPeople)
        {
            for(int i = 0; i < vagon.Length; i++)
            {                
                if (vagon[i].GetNumber() == number) { throw new Exception(); }                                
            }
            Array.Resize(ref vagon, vagon.Length+1);
            vagon[vagon.Length-1].SetCountOfPeople(countOfPeople);
            vagon[vagon.Length-1].SetNumber(number);
        }

       public void DeleteVagon(int number)
        {
            int index = -1;
            for (int i = 0; i < vagon.Length; i++)
            {
                if (vagon[i].GetNumber() == number) { index = i;break; }
            }

            if (index != -1)
            {
                for(int i = index;i< vagon.Length-1; i++)
                {
                vagon[i].SetCountOfPeople(vagon[i+1].GetCountOfPeople());
                vagon[i].SetNumber(vagon[i + 1].GetNumber());
                }
                Array.Resize(ref vagon, vagon.Length-1);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Вагона с таким номером не найдено!");
                throw new Exception();
            }
        }

        public int GetCountfVagons()
        {
            return vagon.Length;
        }

        public void ShowInfoAboutVagons()
        {
            Console.WriteLine("\nКоличество вагонов: " + vagon.Length);
            for (int i = 0; i < vagon.Length; i++)
            {
                Console.WriteLine("\nВагон " + (i+1) + ":");
                Console.WriteLine("Номер вагона: " + vagon[i].GetNumber());
                Console.WriteLine("Количество человек в вагоне: " + vagon[i].GetCountOfPeople());
            }
        }

        public void ShowInfoAboutTrain()
        {
            Console.WriteLine("\nСкорость поезда: " + speed);
            Console.WriteLine("Имя поезда: " + name);
            Console.WriteLine("Количество вагонов: " + vagon.Length);
            Console.WriteLine("Общее кол-во пассажиров: " + GetCountOfAllPeolpe());
        }

        public int GetCountOfAllPeolpe()
        {
            int sum = 0;
            for (int i = 0; i < vagon.Length; i++)
            {
                sum += vagon[i].GetCountOfPeople();
            }
            return sum;
        }

    }
}
