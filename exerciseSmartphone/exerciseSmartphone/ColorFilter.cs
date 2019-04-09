using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseSmartphone
{
    class ColorFilter : IFilter<string>
    {
        public bool Filter(IList<Smartphone> list, string input)
        {
            //dynamic res1 = list.Where(w => w.Color == input).ToList();
            var res = list.Where(w => w.Color == input).ToList();
            if (res != null && res.Count > 0)
            {
                return true;
            }
            return false;
        }

        public List<Smartphone> FilterSmartphones(IList<Smartphone> list, string input)
        {
            return list.Where(w => w.Color == input).ToList();
        }
    }
}
