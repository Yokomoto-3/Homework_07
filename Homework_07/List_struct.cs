using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{

    /// <summary>
    /// Структура для заметок 
    /// </summary>
    struct List_struct
    {
        public int id { get; set; }
        public String date { get; set; }
        public String content { get; set; }
        public int importance { get; set; }
        public String tag { get; set; }

        public List_struct(int _id, String _date, String _content, int _importance, string _tag)
        {
            id = _id;
            date = _date;
            content = _content;
            importance = _importance;
            tag = _tag;
        }
    }
}
