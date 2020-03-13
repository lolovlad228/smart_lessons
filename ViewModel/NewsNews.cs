using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ABdula.Class;
using ABdula.Model;
using System.Collections;
using System.Collections.ObjectModel;

namespace ABdula.ViewModel
{
    class NewsNews:PropertyChange
    {


        private ObservableCollection<News> _News;

        public ObservableCollection<News> News
        {
            get { return _News; }
            set
            {
                _News = value;
                OnProperty("News");
            }
        }

        public NewsNews()
        {
            PdfNewsRead PdfNews = new PdfNewsRead("C:/Users/Vlad/Documents/PdfTest");
            News = PdfNews.ReadInformatin();

        }
    }
}
