using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseSmartphone
{
    interface IFilter<T>
    {
        bool Filter(IList<Smartphone> list, T input);

        List<Smartphone> FilterSmartphones (IList<Smartphone> list, T input);
    }
}
