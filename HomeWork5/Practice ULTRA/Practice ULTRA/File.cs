using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice_ULTRA
{
    public enum typeOfFile
    {
        txt = 0,
        pdf,
        exe,
        png,
    }

    public class File
    {
        public double Size { get; set; }
        public DateTime DateOfCreate { get; set; }
        public typeOfFile type { get; set; }

        public string Name { get; set; }
        public string Data { get; set; }
        public int ID { get; set; }

        public File()
        {
            Size = 0;
            DateOfCreate = DateTime.Now;
            Name = " ";
            Data = " ";
        }

        public void ShowType()
        {
            if (type == typeOfFile.txt) Write("Текстовый");
            else if (type == typeOfFile.png) Write("Изображение");
            else if (type == typeOfFile.pdf) Write("Тип PDF");
            else if (type == typeOfFile.exe) Write("Тип EXE");
        }

        public void ShowInfo()
        {
            Write(Name + "\t");
            Write(DateOfCreate + "\t");
            Write(Size + " КБ\t");
            ShowType();
            WriteLine();
        }

        public void ShowData()
        {
            Write(Data);
        }

        public void SetData(string newData)
        {
            Data = newData;
        }

       

    }
}
