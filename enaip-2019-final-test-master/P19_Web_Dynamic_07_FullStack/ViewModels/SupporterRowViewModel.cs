using P19_Web_Dynamic_07_FullStack.ViewModels;
using System;
using System.Collections.Generic;

namespace P19_Web_Dynamic_07_FullStack.ViewModels
{
    public class SupporterRowViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public int SupportedHero { get; set; }
    }
}
