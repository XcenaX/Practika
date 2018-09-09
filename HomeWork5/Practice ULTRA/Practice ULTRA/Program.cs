using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice_ULTRA
{
    class Program
    {
        static public void PrintMenu()
        {
            WriteLine("Здраствуйте! Это программа по работе с папками и файлами\nНиже показаны функции, которые вы можете использовать\n");
            WriteLine("У вас есть 3 утройства, на которые вы можете \nперекидывать информацию и просматривать её :\nDVD , Flash-память , HDD");
            WriteLine("\n1) Ввести информацию об устройствах");
            WriteLine("2) Расчет общего количества памяти всех утройств");
            WriteLine("3) Копировать информацию из текщей дериктории на другое устройство");
            WriteLine("4) Расчет необходимого количества носителей информации представленных типов для переноса информации");
            WriteLine("5) Создать файл в текущей директории");
            WriteLine("6) Создать папку в текущей директории");
            WriteLine("7) Удалить файл из текущей директории");
            WriteLine("8) Удалить папку из текущей директории");
            WriteLine("9) Показать содержимое текущей директории");
        }

        static public void CalculationOfInformation(Computer computer, DVD dvd)
        {
            WriteLine("Память на вашем ПК: " + computer.BusyMemory / 1000 + "МБ / " + computer.GetAllMemory() + " МБ");
            WriteLine("Память DVD: " + dvd.GetMemory() * 1000 + " МБ");

            double memoryHDD = ((computer.BusyMemory / 1000) / (dvd.GetMemory() * 1000));
            int memoryHdd = Convert.ToInt32((computer.BusyMemory / 1000) / (dvd.GetMemory() * 1000));
            if (memoryHdd <= memoryHDD) memoryHdd++;

            WriteLine("\nВам потребуется " + memoryHdd + " DVD чтобы переместить вашу информацию!");
        }

        static public void CalculationOfInformation(Computer computer, Flash flash)
        {
            WriteLine("Память на вашем ПК: " + computer.BusyMemory / 1000 + "МБ / " + computer.GetAllMemory() + " МБ");
            WriteLine("Память Flash: " + flash.GetMemory() * 1000 + " МБ");

            double memoryHDD = ((computer.BusyMemory / 1000) / (flash.GetMemory() * 1000));
            int memoryHdd = Convert.ToInt32((computer.BusyMemory / 1000) / (flash.GetMemory() * 1000));
            if (memoryHdd <= memoryHDD) memoryHdd++;

            WriteLine("\nВам потребуется " + memoryHdd + " Flash чтобы переместить вашу информацию!");
        }

        static public void CalculationOfInformation(Computer computer, HDD hdd)
        {
            WriteLine("Память на вашем ПК: " + computer.BusyMemory / 1000 + "МБ / " + computer.GetAllMemory() + " МБ");
            WriteLine("Память HDD: " + hdd.GetMemory() * 1000 + " МБ");

            double memoryHDD = ((computer.BusyMemory / 1000) / (hdd.GetMemory() * 1000));
            int memoryHdd = Convert.ToInt32((computer.BusyMemory / 1000) / (hdd.GetMemory() * 1000));
            if (memoryHdd <= memoryHDD) memoryHdd++;

            WriteLine("\nВам потребуется " + memoryHdd + " HDD чтобы переместить вашу информацию!");
        }

        static public void AllDevicesMemory(HDD hdd, Flash flash, DVD dvd)
       {           

            hdd.ShowInfo();
            ReadKey();
            Clear();

            flash.ShowInfo();
            ReadKey();
            Clear();

            dvd.ShowInfo();
            ReadKey();
            Clear();

            double allMemory = (hdd.BusyMemory + flash.BusyMemory + dvd.BusyMemory) /1000;

            Write("Общая память всех утройств:" + allMemory + " MБ");            
        }

        

        static void Main(string[] args)
        {
            Computer computer = new Computer();
            DVD dvd = new DVD();
            Flash flash = new Flash();
            HDD hdd = new HDD();

            bool isInputInfo = false;

            bool checkError = true;

            while (checkError)
            {
                PrintMenu();
            char select = ReadKey().KeyChar;
                switch (select)
                {
                    case '1':
                        isInputInfo = true;
                        Clear();
                        WriteLine("Для начала введите информацию об устройствах:");

                        dvd.InputInfo();

                        flash.InputInfo();

                        hdd.InputInfo();
                        Clear();
                        break;
                    case '2':
                        Clear();
                        AllDevicesMemory(hdd,flash,dvd);
                        ReadKey();
                        Clear();                        
                        break;
                    case '3':
                        Clear();
                        WriteLine("Выберите устройство:");
                        Write("1) HDD");
                        Write("\n2) DVD");
                        WriteLine("\n3) Flash-память");

                        char selectDevice = ReadKey().KeyChar;
                        switch (selectDevice)
                        {
                            case '1':
                                hdd.CopyMemory(computer);
                                break;
                            case '2':
                                dvd.CopyMemory(computer);
                                break;
                            case '3':
                                flash.CopyMemory(computer);
                                break;
                            default:
                                Clear();
                                break;
                        }
                        Clear();
                        break;                   
                    case '4':
                        Clear();
                        if (!isInputInfo)
                        {
                            WriteLine("Сначала заполните информацию об устройствах! \n(Пункт 1)");
                            ReadKey();
                            Clear();
                                break;
                        }

                        bool checkDevice = false;
                        char device;

                        while (!checkDevice)
                        {
                        WriteLine("Выберите устройсто: ");

                        WriteLine("1) DVD");
                        WriteLine("2) HDD");
                        WriteLine("3) Flash");

                            device = ReadKey().KeyChar;

                            switch (device)
                            {
                                case '1':
                                    CalculationOfInformation(computer, dvd);
                                    checkDevice = true;
                                    break;
                                case '2':
                                    CalculationOfInformation(computer, hdd);
                                    checkDevice = true;
                                    break;
                                case '3':
                                    CalculationOfInformation(computer, flash);
                                    checkDevice = true;
                                    break;
                                default:
                                    Clear();
                                    break;
                            }
                        }
                        ReadKey();
                        Clear();
                        break;
                    case '5':
                        Clear();
                        Write("Введите имя файла: ");
                        string name = ReadLine();

                        if (name.Length == 0)
                        {
                            Clear();
                            WriteLine("Имя папки слишком короткое!");
                            ReadKey();
                            Clear();
                            break;
                        }

                        else if (name.Contains("<") || name.Contains(">") || name.Contains("/") || name.Contains("*") || name.Contains("?"))
                        {
                            Clear();
                            Write("В имени файла не должно присутсвовать этих символов:\n");
                            Write("/ < > * ?");
                            ReadKey();
                            Clear();
                            break;
                        }

                        else if (computer.CheckSameName(name, computer.GetFiles()) == false)
                        {
                            Clear();
                            WriteLine("Файл с таким именем уже существует!");
                            ReadKey();
                            Clear();
                            break;
                        }

                        bool check = false;
                        typeOfFile type = 0;

                        while (!check)
                        {
                        WriteLine("Выберите тип файла:");
                        WriteLine("1) текстовый");
                        WriteLine("2) exe файл");
                        WriteLine("3) pdf файл");
                        WriteLine("4) png файл");
                            char selectType = ReadKey().KeyChar;
                            switch (selectType)
                            {
                                case '1':
                                    type = typeOfFile.txt;
                                    check = true;
                                    break;
                                case '2':
                                    type = typeOfFile.exe;
                                    check = true;
                                    break;
                                case '3':
                                    type = typeOfFile.pdf;
                                    check = true;
                                    break;
                                case '4':
                                    type = typeOfFile.png;
                                    check = true;
                                    break;
                                default:
                                    Clear();
                                    break;
                            }
                        }

                        string data = "";

                        if (type != typeOfFile.png)
                        {
                            Write("\nВведите содержимое файла: ");
                             data = ReadLine();
                        }
                        computer.AddFile(name,data,type);
                        Clear();
                        break;
                    case '6':
                        Clear();
                        Write("Введите имя Папки: ");
                        string nameOfFolder = ReadLine();

                        if (nameOfFolder.Length == 0)
                        {
                            Clear();
                            WriteLine("Имя папки слишком короткое!");
                            break;
                        }

                        else if (nameOfFolder.Contains("<") || nameOfFolder.Contains(">") || nameOfFolder.Contains("/") || nameOfFolder.Contains("*") || nameOfFolder.Contains("?"))
                        {
                            Clear();
                            Write("В имени файла не должно присутсвовать этих символов:\n");
                            Write("/ < > * ?");
                            ReadKey();
                            Clear();
                            break;
                        }

                        if (computer.CheckSameName(nameOfFolder, computer.GetFolders()) == false)
                        {
                            Clear();
                            WriteLine("Папка с таким именем уже существует!");
                            ReadKey();
                            Clear();
                            break;
                        }

                        computer.AddFolder(nameOfFolder);

                        break;
                    case '7':
                        Clear();
                        computer.ShowContent(computer.GetFiles(), computer.GetFolders());
                        Write("\nВведите имя файла: ");
                        string nameOfFile = ReadLine();
                        computer.DeleteFile(nameOfFile);
                        Clear();
                        computer.ShowContent(computer.GetFiles(), computer.GetFolders());
                        ReadKey();
                        Clear();
                        break;
                    case '8':
                        Clear();
                        computer.ShowContent(computer.GetFiles(), computer.GetFolders());
                        Write("\nВведите имя папки: ");
                        string folderName = ReadLine();
                        computer.DeleteFolder(folderName);
                        Clear();
                        computer.ShowContent(computer.GetFiles(), computer.GetFolders());
                        ReadKey();
                        Clear();
                        break;
                    case '9':                       
                        int id;
                        

                        while (true)
                        {
                        Clear();
                        computer.ShowContent(computer.GetFiles(), computer.GetFolders());
                        string choose = ReadLine();
                            if (choose == "") break;
                            else if (choose == "w")
                            {
                                if(computer.Way != "C:/")
                                {
                                computer.GoUp();
                                }                               
                            }

                            else if(!int.TryParse(choose, out id))
                            {
                                Clear();
                            }
                            else
                            {
                                Folder[] foldersTest = computer.GoDown(id, computer.GetFolders());

                                if(foldersTest != null)
                                {
                                computer.SetFile(computer.GetFolderUseID(id, computer.GetFolders()).GetFiles());
                                computer.SetFolder(foldersTest);
                                }
                                computer.ShowContent(computer.GetFiles(), computer.GetFolders());
                                
                            }
                            Clear();
                        }


                        Clear();
                        break;
                    default:
                        Clear();
                        break;
                }
            }

        }
    }
}
