using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice_ULTRA
{
   public enum typeOfDVD
    {
        no = 0,
        unilateral, // односторонний
        bilateral // двусторонний
    }

    public class DVD : Storage
    {
        public double SpeedOfRead { get; set; }
        public double SpeedOfWrite { get; set; }
        public typeOfDVD type { get; set; }
        public double BusyMemory { get; set; }

        private Folder[] folders;
        private File[] files;

        public DVD()
        {
            folders = new Folder[0];
            files = new File[0];
            SpeedOfRead = 0;
            SpeedOfWrite = 0;
            type = typeOfDVD.no;
            BusyMemory = 0;
        }

        public override double GetMemory()
        {
            if (type == typeOfDVD.unilateral) { return 4.7; }
            return 9;                      
        }

        public void Add(Folder[] folders)
        {
            bool checkSame = false;

            for (int i = 0; i < folders.Length; i++)
            {
                 checkSame = false;
                for (int j = 0; j < this.folders.Length; j++)
                {
                    if(this.folders[j].Name == folders[i].Name)
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
            WriteLine("\n\n\nDVD: ");

            WriteLine("Память: "+ BusyMemory /1000+ " МБ / " + GetMemory()*1000 + " МБ");
            WriteLine("Скорость чтения: " + SpeedOfRead);
            WriteLine("Скорость записи: " + SpeedOfWrite);
            if(type == typeOfDVD.unilateral)WriteLine("Тип: Односторонний (4,7 гигабайт)");
            else if(type == typeOfDVD.bilateral) WriteLine("Тип: Двусторонний (9 гигабайт)");
            else WriteLine("Тип: нет (0 гигабайт)");

            WriteLine("\nСодержание DVD:");
            WriteLine("\nИмя\tДата Создания\tРазмер\tТип");

            for (int i = 0; i< files.Length; i++)
            {
                files[i].ShowInfo();
            }

            for (int i = 0; i < folders.Length; i++)
            {
                folders[i].ShowContent();
            }

            if (folders.Length == 0 && files.Length == 0)
            {
                Write("\n\tВ DVD Пусто!");
            }

        }
        public override double GetFreeMemory()
        {
            double memory = GetMemory() * 1000 * 1000; // в КБ
            return memory - BusyMemory;
        }

        public void InputInfo()
        {

            bool checkEnd = false;

            while (!checkEnd)
            {
                Clear();
                WriteLine("\nDVD-память:");
                WriteLine("Введите тип DVD: ");
                WriteLine("\n1) Односторонний (4,7 GB)");
                WriteLine("2) Двусторонний (9 GB)");
                char select = ReadKey().KeyChar;
                switch (select)
                {
                    case '1':
                        type = typeOfDVD.unilateral;                        
                        checkEnd = true;
                        break;
                    case '2':
                        type = typeOfDVD.bilateral;
                        checkEnd = true;
                        break;
                    default:
                        Clear();
                        break;
                }
            }

            while (true)
            {
                Clear();
                WriteLine("Введите скорость четния (МБ/СЕК): ");

                string toParse = ReadLine();
                int speedOfRead;

                if(int.TryParse(toParse, out speedOfRead))
                {
                    SpeedOfRead = speedOfRead;
                    break;
                }
            }

            while (true)
            {
                Clear();
                WriteLine("Введите скорость записи (МБ/СЕК): ");

                string toParse = ReadLine();
                int speedOfWrite;

                if (int.TryParse(toParse, out speedOfWrite))
                {
                    SpeedOfWrite = speedOfWrite;
                    break;
                }
            }
        }
    }
}
