using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Practice_ULTRA
{
    public class Folder
    {
        public DateTime DateOfCreate { get; set; }

        public double Size { get; set; }

        public string Name { get; set; }

        private File[] files;

        private Folder[] folders;

        public int ID { get; set; }     

        public void SetFile(int index, string data)
        {
            files[index].Name = data;
        }

        public string GetFileData(int index)
        {
            return files[index].Data;
        }

        public Folder[] GetFolders()
        {
            return folders;
        }

        public int GetCountOfFiles()
        {
            return files.Length;
        }

        public File[] GetFiles()
        {
            return files;
        }

        public void SetFolders(Folder[] folders)
        {
            this.folders = folders;
        }

        public void SetFiles(File[] files)
        {
            this.files = files;
        }

       public Folder()
        {
            files = new File[0];
            folders = new Folder[0];
            Size = 0;
            DateOfCreate = DateTime.Now;
            Name = "";
            ID = -1;            
        }

        public void ShowContent()
        {
                Write(Name + "\t");
                Write(DateOfCreate + "\t");
                Write(Size + " КБ\t");
                Write("Папка");
                WriteLine();            
        }
    }
}
