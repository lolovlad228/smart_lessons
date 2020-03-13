using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABdula.Class;

namespace ABdula.Model
{
    class News : PropertyChange
    {
        private string _Title;
        private string _News;
        private DateTime _DateTimePub;

        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnProperty("Title");
            }
        }

        public string NewsInfo
        {
            get { return _News; }
            set
            {
                _News = value;
                OnProperty("NewsInfo");
            }
        }

        public DateTime DateTimePub
        {
            get { return _DateTimePub; }
            set
            {
                _DateTimePub = value;
                OnProperty("DateTimePub");
            }
        }

    }
}
