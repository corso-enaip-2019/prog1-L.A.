using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P19_Web_Dynamic_07_FullStack_ANTONELLI.ViewModels
{
    public class SupporterAddViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public DateTime Birth { get; set; }

        //public int? SuperheroId { get; set; }
    }
}
