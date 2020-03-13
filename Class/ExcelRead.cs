using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using ABdula.Model;
using System.Collections.ObjectModel;

namespace ABdula.Class
{
    class ExcelRead:IReadInfo<Lessons>
    {
        private string _Name;
        private _Application Excl = new _Excel.Application();
        private Workbook Workbook;
        private Worksheet Worksheet;

        public void WorksheetsNew(int id)
        {
            try
            {
                Worksheet = Workbook.Worksheets[id];
            }
            catch
            {
                Worksheet = Workbook.Worksheets[1];
            }
            
        }
        public ExcelRead(string name, int id)
        {
            _Name = name;
            Workbook = Excl.Workbooks.Open(name);
            Worksheet = Workbook.Worksheets[id];
        }


        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (Worksheet.Cells[i, j].Value2 != null)
                return Worksheet.Cells[i, j].Value2;
            return "";
        }

        public Lessons ReadDay(int id)
        {
            Lessons lessons = new Lessons();
            lessons.Name = ReadCell(1, id);
            List<string> Ls = new List<string>();
            for(int i = 0; i < 8; i++)
            {
                Ls.Add(ReadCell(2 + i, id));
            }
            lessons.LessonsList = Ls;
            return lessons;
        }

        public ObservableCollection<Lessons> ReadInformatin()
        {
            ObservableCollection<Lessons> Ls = new ObservableCollection<Lessons>();
            for (int i = 0; i < 6; i++)
            {
                Lessons lessons = new Lessons();
                lessons = ReadDay(i);
                Ls.Add(lessons);
            }
            
            return Ls;
        }
        public void CloseActin()
        {
            Workbook.Close();
        }
    }
}
