using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using ABdula.View;
using System.Runtime.CompilerServices;
using ABdula.Class;
using System.Windows;

namespace ABdula.ViewModel
{
    class MainViewModel : PropertyChange
    {
        private Page News;
        private Page Lessions;
        private Page _PageShow;


        public Page PageShow
        {
            get { return _PageShow; }
            set
            {
                _PageShow = value;
                OnProperty("PageShow");
            }
        }

        public ICommand SelectNews { get; private set; }
        public ICommand SelectLes { get; private set; }


        public MainViewModel()
        {
            News = new PageNews();
            Lessions = new PageLessions();

            SelectNews = new RealCom(NewsComm);
            SelectLes = new RealCom(LessonsComm);
            PageShow = News;
        }

        private void NewsComm(object param)
        {
            PageShow = News;

        }

        private void LessonsComm(object param)
        {
            PageShow = Lessions;
        }

       
    }
}
