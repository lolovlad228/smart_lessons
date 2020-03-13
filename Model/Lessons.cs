using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABdula.Class;

namespace ABdula.Model
{
    class Lessons:PropertyChange
    {
        private List<string> _Lessons;
        private string _Name;

        public List<string> LessonsList
        {
            get { return _Lessons; }
            set
            {
                _Lessons = value;
                OnProperty("LessonsList");
            }
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnProperty("Name");
            }
        }
    }
}
