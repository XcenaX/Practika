using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Practice_ULTRA
{
    public class Computer
    {
        private Folder[] folders;
        private File[] files;
        private List<Folder[]> backFolders;
        private List<File[]> backFiles;
        private const double Memory = 100000; // мегабайт
        public double BusyMemory { get; set; }
        public string Way { get; set; }


        public Computer()
        {
            files = new File[0];
            folders = new Folder[0];
            backFolders = new List<Folder[]>();
            backFiles = new List<File[]>();
            Way = "C:/";
        }

        public void AddFile(string nameOfFile, string data, typeOfFile type)
        {
            if (((data.Length * sizeof(char))/1000 + BusyMemory) > Memory)
            {
                Clear();
                WriteLine("Недостаточно памяти!");
                ReadKey();
                Clear();
                return;
            }

            bool checkCopy = false;
            for (int i = 0; i < files.Length; i++) {
                if (nameOfFile == files[i].Name)
                {
                    Console.WriteLine("\nФайл с таким именем уже существует!");
                    checkCopy = true;
                    break;
                }
            }
            if (!checkCopy)
            {
                Array.Resize(ref files, files.Length + 1);
                if (type == typeOfFile.png) data = "\t\t"; // для того чтобы png файл не весил 0 КБ
                this.files[files.Length - 1] = new File
                {
                    Data = data,
                    Name = nameOfFile,
                    type = type,
                    Size = data.Length * sizeof(char),
                    ID = -1
                };
                BusyMemory += files[files.Length - 1].Size;

                if (Way != "C:/")
                {
                    string[] bufWay = Way.Split('/');

                    Folder[] bufFolder = folders;
                    File[] bufFile = files;

                    folders = backFolders[backFolders.Count - 1];
                    files = backFiles[backFiles.Count - 1];

                    for (int j = 0; j < folders.Length; j++)
                    {
                        if (folders[j].Name == bufWay[bufWay.Length - 2])
                        {
                            folders[j].Size += bufFile[bufFile.Length - 1].Size;

                            folders[j].SetFolders(bufFolder);
                            folders[j].SetFiles(bufFile);

                            files = bufFile;
                            folders = bufFolder;
                            break;
                        }
                    }
                }
                Console.WriteLine("\nФайл успешно добавлен!");
                ReadKey();
            }
        }

        public void SetFile(File file, int index)
        {
            files[index] = file;
        }

        public void AddFolder(string nameOfFolder)
        {
            
            Array.Resize(ref folders, folders.Length + 1);

            this.folders[folders.Length - 1] = new Folder
            {
                Name = nameOfFolder,
                ID = -1,               
            };

            if (Way != "C:/")
            {
                string[] bufWay = Way.Split('/');

                Folder[] bufFolder = folders;
                File[] bufFile = files;

                folders = backFolders[backFolders.Count - 1];
                files = backFiles[backFiles.Count - 1];

                for (int j = 0; j < folders.Length; j++)
                {
                    if (folders[j].Name == bufWay[bufWay.Length - 2])
                    {
                        folders[j].SetFolders(bufFolder);
                        folders[j].SetFiles(bufFile);

                        folders = bufFolder;
                        files = bufFile;
                        break;
                    }
                }
            }

            Console.WriteLine("\nПапка успешно добавлена!");
            ReadKey();
            Clear();
        }

        public double GetAllMemory()
        {
            return Memory;
        }

        public void ShowContent(File[] files, Folder[] folders)
        {
            WriteLine("Чтобы посмотреть содержимое файла/папки\nнажмите на цифру которая стоит перед именем папки/файла\n");
            WriteLine("Чтобы выйти в главное меню нажмите ENTER\n");
            WriteLine("Чтобы вернутся в предыдушую папку нажмите 'w'\n");
            WriteLine("Память: " + BusyMemory / 1000 + "МБ / " + GetAllMemory() + " МБ");
            WriteLine("\nПуть: " + Way);
            WriteLine("\n  Имя\t\tДата Создания\t\tРазмер\tТип");

            int I = 1;
            for (int i = 0; i < files.Length; I++, i++)
            {
                files[i].ID = I;
                Write(I + " ");
                Write(files[i].Name + "\t\t");
                Write(files[i].DateOfCreate + "\t");
                Write(files[i].Size + " КБ\t");
                files[i].ShowType();
                WriteLine();
            }

            for (int i = 0; i < folders.Length; i++, I++)
            {
                folders[i].ID = I;
                Write(I + " ");
                Write(folders[i].Name + "\t\t");
                Write(folders[i].DateOfCreate + "\t");
                Write(folders[i].Size + " КБ\t");
                Write("папка");
                WriteLine();
            }
        }

        public bool CheckSameName(string name, File[] files)
        {
            for (int i = 0; i < files.Length; i++)
            {
                if (name == files[i].Name) return false;
            }
            return true;
        }

        public bool CheckSameName(string name, Folder[] folders)
        {
            for (int i = 0; i < folders.Length; i++)
            {
                if (name == folders[i].Name) return false;
            }
            return true;
        }

        public int GetCountOfFiles()
        {
            return files.Length;
        }

        public int GetCountOfFolders()
        {
            return folders.Length;
        }

        public File GetFile(int index)
        {
            return files[index];
        }

        public File[] GetFiles()
        {
            return files;
        }

        public Folder GetFolder(int index)
        {
            return folders[index];
        }

        public Folder[] GetFolders()
        {
            return folders;
        }

        public void SetFile(File[] file)
        {
            files = file;
        }

        public void SetFolder(Folder[] folder)
        {
            folders = folder;
        }

        public Folder GetFolderUseID(int id, Folder[] folders)
        {
            for (int i = 0; i < folders.Length; i++)
            {
                if (folders[i].ID == id)
                {
                    return folders[i];
                }
            }
            return null;
        }

        public void SetFolder(Folder folder, int index)
        {
            folders[index] = folder;
        }

        public void DeleteFile(string name)
        {
            
            if (Way != "C:/")
            {
                string[] bufWay = Way.Split('/');

                Folder[] bufFolder = folders;
                File[] bufFile = files;

                folders = backFolders[backFolders.Count - 1];
                files = backFiles[backFiles.Count - 1];


                for (int j = 0; j < folders.Length; j++)
                {
                    if (folders[j].Name == bufWay[bufWay.Length - 2])
                    {
                        folders[j].Size -= bufFile[files.Length - 1].Size;

                        folders[j].SetFolders(bufFolder);
                        folders[j].SetFiles(bufFile);

                        files = bufFile;
                        folders = bufFolder;
                        break;
                    }
                }
            }

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name == name)
                {
                    if (files.Length == 1)
                    {
                        BusyMemory -= files[0].Size;
                        Array.Resize(ref files, 0);                        
                        return;
                    }
                    else
                    {
                        BusyMemory -= files[i].Size;

                        for (int j = i; j < files.Length - 1; j++)
                        {
                            SetFile(files[j + 1], j);
                        }

                        Array.Resize(ref files, files.Length - 1);                        
                        return;
                    }
                }
            }            
            Clear();
            Write("\nТакого файла не найдено!");
            ReadKey();
        }

        public void DeleteFolder(string name)
        {
            for (int i = 0; i < folders.Length; i++)
            {
                if (folders[i].Name == name)
                {
                    BusyMemory -= folders[i].Size;
                    if (folders.Length == 1)
                    {
                        Array.Resize(ref folders, folders.Length - 1);
                        if(Way!="C:/")backFolders[backFolders.Count - 1] = folders;
                        return;
                    }
                    else
                    {
                        for (int j = i; j < folders.Length - 1; j++)
                        {
                            SetFolder(folders[j + 1], j);
                        }
                        Array.Resize(ref folders, folders.Length - 1);

                        if (Way != "C:/")
                        {
                            string[] bufWay = Way.Split('/');

                            Folder[] bufFolder = folders;
                            File[] bufFile = files;

                            folders = backFolders[backFolders.Count - 1];
                            files = backFiles[backFiles.Count - 1];

                            for (int j = 0; j < folders.Length; j++)
                            {
                                if (folders[j].Name == bufWay[bufWay.Length - 2])
                                {
                                    folders[j].SetFolders(bufFolder);
                                    folders[j].SetFiles(bufFile);

                                    folders = bufFolder;
                                    files = bufFile;
                                    break;
                                }
                            }
                        }
                        return;
                    }
                }
            }
            Clear();
            Write("\nТакой папки не найдено!");
            ReadKey();
        }

        public Folder[] GoDown(int ID, Folder[] folders)
        {
            for (int i = 0; i < folders.Length; i++)
            {
                if (folders[i].ID == ID)
                {
                    this.Way += folders[i].Name + "/";

                    backFolders.Add(folders);
                    backFiles.Add(files);

                    return folders[i].GetFolders();
                }
            }

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].ID == ID)
                {
                    Clear();
                    WriteLine("Если хотите изменить этот документ, то нажмите 1\n");
                    WriteLine("Содержимое: \n");
                    files[i].ShowData();

                    char choose = ReadKey().KeyChar;

                    switch (choose)
                    {
                        case '1':
                            Clear();
                            Write("Введите содержимое файла: ");
                            string data = ReadLine();
                            files[i].Data = data;
                            files[i].Size = data.Length * sizeof(char);
                            break;
                        default:
                            Clear();
                            break;
                    }
                    break;
                }
            }

            return null;
        }

        public void GoUp()
        {
            folders = backFolders[backFolders.Count-1];
            files = backFiles[backFiles.Count - 1];

            backFolders.RemoveAt(backFolders.Count-1);
            backFiles.RemoveAt(backFiles.Count - 1);

            string[] buf = Way.Split('/');
            Way = "";

            for(int i = 0; i < buf.Length - 2; i++)
            {
                Way += buf[i] + "/";
            }
         
        }

        public double GetBusyMemoryOfDirectory()
        {
            double memory = 0;

            for(int i = 0; i < folders.Length; i++)
            {
                memory += folders[i].Size;
            }
            for(int i = 0; i < files.Length; i++)
            {
                memory += files[i].Size;
            }
            return memory;
        }

    }
}
