using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABdula.Model;
using ABdula.Class;
using System.Windows.Controls;
using System.Windows;
using System.Collections;
using System.Collections.ObjectModel;

namespace ABdula.ViewModel
{
    class LessonsViewModel : PropertyChange
    {
        private ObservableCollection<Lessons> _ListInfo;
        private ComboBoxItem _SelectId;
        private ExcelRead _Read = new ExcelRead("C:/Users/Vlad/Documents/Test2.xlsx", 1);
        private List<ObservableCollection<Lessons>> _ListLessons = new List<ObservableCollection<Lessons>>();

        public ObservableCollection<Lessons> ListInfo
        {
            get { return _ListInfo; }
            set
            {
                _ListInfo = value;
                OnProperty("ListInfo");
            }
        }

        public ComboBoxItem SelectId
        {
            get { return _SelectId; }
            set
            {
                _SelectId = value;
                ListInfo = _ListLessons[Convert.ToInt32(_SelectId.Content.ToString().Substring(0, 2).Replace(" ", "")) - 1];
                OnProperty("SelectId");
            }
        }

        public LessonsViewModel()
        {
            ListInfo = new ObservableCollection<Lessons>();
            for(int i = 1; i <= 11; i++)
            {
                LoadLes(i);
            }

            _Read.CloseActin();
        }

        private void LoadLes(int Id)
        {
            _Read.WorksheetsNew(Id);
            _ListLessons.Add(_Read.ReadInformatin());
        }

    }
}
