using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseSmartphone
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Smartphone> (mockSmartphones)getsmartphones = new List<Smartphone>();
            List<Smartphone> getMockSmartphones = GetMockSmartphones();
            bool existingBlackSmartphones = new ColorFilter().Filter(getMockSmartphones, "red");
            Console.WriteLine($"Smartphone black {existingBlackSmartphones}");
            List<Smartphone> blackSmartphones = new ColorFilter().FilterSmartphones(getMockSmartphones, "black");
            foreach (Smartphone item in blackSmartphones)
            {
                Console.WriteLine($"Smartphone black: {item.Model}, {item.Price}, {item.Version} ");
            }

            Console.WriteLine("Insert the maximum price of the Smartphone you want to pay for");
            string inputPrice = Console.ReadLine();
            List<Smartphone> priceSpartphones = getMockSmartphones.Where(w => w.Price < Convert.ToDouble(inputPrice)).ToList();
            foreach (Smartphone item in priceSpartphones)
            {
                Console.WriteLine($"The Smartphones you can afford are: {item.Model}, {item.Price}, {item.Version}, {item.Color} ");
            }
            Console.ReadKey();

        }




        static List<Smartphone> GetMockSmartphones()
        {
            return new List<Smartphone>()
            {
                new Smartphone("pocophone", "2b", "gold", 109.99),
                new Smartphone("xiaomi", "3db", "white", 179.99),
                new Smartphone("samsung", "2.0", "black", 109.99)
            };
        }

    }

  

}

