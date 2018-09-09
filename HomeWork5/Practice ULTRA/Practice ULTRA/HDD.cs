using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice_ULTRA
{
    public class HDD : Storage
    {
        private const double speed = 480;
        public int CountOfPartitions { get; set; }
        public double VolumeOfSections { get; set; }
        public double BusyMemory { get; set; }
        private Folder[] folders;
        private File[] files;

        public HDD()
        {
            folders = new Folder[0];
            files = new File[0];
            CountOfPartitions = 0;
            VolumeOfSections = 0;
            BusyMemory = 0;
        }

        public override double GetMemory()
        {
            return CountOfPartitions * VolumeOfSections;
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
            if (GetFreeMemory()*1000*1000 >= computer.GetBusyMemoryOfDirectory())
            {
                for (int i = 0; i < computer.GetFolders().Length; i++)
                {                    
                    Add(computer.GetFolders());
                }
                for(int i = 0; i < computer.GetFiles().Length; i++)
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
            WriteLine("\n\n\nHDD: ");

            WriteLine("Скорость мегабит: " + speed);
            WriteLine("Память: " + BusyMemory/1000 + " МБ / " + GetMemory()*1000 + " МБ");
            WriteLine("Количество разделов: " + CountOfPartitions);
            WriteLine("Объём одного рздела: " + VolumeOfSections + " GB");

            WriteLine("\nСодержание HDD:");
            WriteLine("\nИмя\tДата Создания\tРазмер\tТип");

            for (int i = 0; i < files.Length; i++)
            {
                files[i].ShowInfo();
            }

            for (int i = 0; i < folders.Length; i++)
            {
                folders[i].ShowContent();
            }

            if(folders.Length == 0 && files.Length == 0)
            {
                Write("\n\tВ HDD Пусто!");
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
                WriteLine("\nHDD-память:");
                Write("Введите размер одного раздела в гигабайтах: ");

                string toParse = ReadLine();
                int size;

                if (int.TryParse(toParse, out size))
                {
                    VolumeOfSections = size;
                    break;
                }
            }
            while (true)
            {
                Clear();
                Write("\nВведите количество разделов: ");

                string toParse = ReadLine();
                int count;

                if (int.TryParse(toParse, out count))
                {
                    CountOfPartitions = count;
                    break;
                }
            }
        }

    }
}
