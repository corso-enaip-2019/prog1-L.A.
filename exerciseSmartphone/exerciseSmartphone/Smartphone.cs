using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseSmartphone
{
    
        public class Smartphone
        {
            public string Model { get; }
            public string Version { get; }
            public string Color { get; }
            public double Price { get; set; }

            public Smartphone(string model, string version, string color, double price)
            {
                Model = model;
                Version = version;
                Color = color;
                Price = price;
            }
        }
    }

