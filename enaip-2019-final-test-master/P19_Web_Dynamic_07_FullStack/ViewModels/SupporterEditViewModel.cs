using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P19_Web_Dynamic_07_FullStack_ANTONELLI.ViewModels
{
    public class SupporterEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public int SupportedHero { get; set; }
    }
}
