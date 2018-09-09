using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice_ULTRA
{
    public class Flash : Storage
    {
        private const double speedInMb = 5000; 
        public double MemorySize { get; set; }
        public double BusyMemory { get; set; }

        private Folder[] folders;
        private File[] files;

        public Flash()
        {
            MemorySize = 0;
            folders = new Folder[0];
            files = new File[0];
            BusyMemory = 0;
        }

        public double GetSpeed()
        {
            return speedInMb;
        }

        public override double GetMemory()
        {
            return MemorySize;
        }

        public void Add(Folder[] folders)
        {
            bool checkSame = false;

            for (int i = 0; i < folders.Length; i++)
            {
                checkSame = false;
                for (int j = 0; j < this.folders.Length; j++)
                {
                    if (this.folders[j].Name == folders[i].Name)
                    {
                        checkSame = true;
                        break;
                    }
                }
                if (!checkSame)
                {
                    Array.Resize(ref this.folders, this.folders.Length + 1);
                    this.folders[this.folders.Length - 1] = new Folder();
                    this.folders[this.folders.Length - 1] = folders[i];
                    BusyMemory += folders[i].Size;
                }
            }
        }

        public void Add(File[] files)
        {
            bool checkSame = false;

            for (int i = 0; i < files.Length; i++)
            {
                checkSame = false;
                for (int j = 0; j < this.files.Length; j++)
                {
                    if (this.files[j].Name == files[i].Name)
                    {
                        checkSame = true;
                        break;
                    }
                }
                if (!checkSame)
                {
                    Array.Resize(ref this.files, this.files.Length + 1);
                    this.files[this.files.Length - 1] = new File();
                    this.files[this.files.Length - 1] = files[i];
                    BusyMemory += files[i].Size;
                }
            }
        }

        public override void CopyMemory(Computer computer)
        {
            if (GetFreeMemory() * 1000 * 1000 >= computer.GetBusyMemoryOfDirectory())
            {
                for (int i = 0; i < computer.GetFolders().Length; i++)
                {
                    Add(computer.GetFolders());
                }
                for (int i = 0; i < computer.GetFiles().Length; i++)
                {
                    Add(computer.GetFiles());
                }
            }
            else
            {
                Clear();
                WriteLine("Недостаточно памяти для копирования!");
                ReadKey();
                Clear();
                return;
            }
        }

        public override void ShowInfo()
        {
            WriteLine("\n\n\nFlash: ");

            WriteLine("Скорость в мегабайтах в секунду: " + speedInMb);
            WriteLine("Память: " + BusyMemory/1000 + " МБ / " + GetMemory() * 1000 + " МБ");
            WriteLine("Память: " + GetMemory() + " GB");
            

            WriteLine("\nСодержание Flash:");
            WriteLine("\nИмя\tДата Создания\tРазмер\tТип");

            for (int i = 0; i < files.Length; i++)
            {
                files[i].ShowInfo();
            }

            for (int i = 0; i < folders.Length; i++)
            {
                folders[i].ShowContent();
            }

            if (folders.Length == 0 && files.Length == 0)
            {
                Write("\n\tВ Flash-памяти Пусто!");
            }

        }
        public override double GetFreeMemory()
        {
            double memory = GetMemory();
            return memory - BusyMemory;
        }

        public void InputInfo()
        {
            while (true)
            {
                Clear();
                WriteLine("\nFlash-память:");
                Write("Введите размер памяти в гигабайтах: ");

                string toParse = ReadLine();
                int size;

                if (int.TryParse(toParse, out size))
                {
                    MemorySize = size;
                    break;
                }
            }
        }

    }
}
