using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABdula.Model;

namespace ABdula.Class
{
    interface IReadInfo<T> where T : class
    {
        ObservableCollection<T> ReadInformatin();
    }
}
