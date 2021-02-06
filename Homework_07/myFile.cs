using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
   
    static class myFile
    {
        private static string path = Directory.GetCurrentDirectory() + @"\file.txt";
        
        public static ObservableCollection<List_struct> load()
        {
            ObservableCollection<List_struct> list = new ObservableCollection<List_struct>();
            using (StreamReader reader = File.OpenText(path))
            {
                while (!reader.EndOfStream)
                {
                    int id = int.Parse(reader.ReadLine());
                    string name = reader.ReadLine();
                    string type = reader.ReadLine();
                    int movility = int.Parse(reader.ReadLine());
                    string lifeTime = reader.ReadLine();
                    list.Add(new List_struct(id,name, type, movility, lifeTime));
                }
            }
            return list;
        }
        
        public static void save(ObservableCollection<List_struct> list)
        {
            using (StreamWriter sr = new StreamWriter(path))
            {
                foreach (var item in list)
                {
                    sr.WriteLine(item.id);
                    sr.WriteLine(item.date);
                    sr.WriteLine(item.content);
                    sr.WriteLine(item.importance);
                    sr.WriteLine(item.tag);
                }
                sr.Close();
            }
        }
    }
}