using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //1) inquilini di tutti gli appartamenti di classe energetica A o B
            //2) media del numero di inquilini (di tutti gli appartamenti).
            //3) di ogni città, nome di città ed elenco di vie degli appartamenti
            //4) di ogni città, nome di città e media dei metri quadri
            //5) di ogni città, nome di città e media di metri quadri, tutti ordinati per nome di città, e dentro la città ordinati per via. (=> orderBy)
            //6) elenco dei nomi di città che hanno solo appartamenti non in classe A, B, C

            List<Flat> apartmani = new List<Flat>()
            {
                new Flat (50, "via roma 5", "trieste", 3, EnergyClassType.A),
                new Flat (150, "via dei capitelli 8/a", "venezia", 5, EnergyClassType.C),
                new Flat (250, "via economo 15", "roma", 2, EnergyClassType.B),
                new Flat (30, "via trento 1", "palermo", 14, EnergyClassType.C),
                new Flat (80, "via gessi 10", "trento", 1, EnergyClassType.D ),
            };


            //int sommaInquiliniApartmani = GetFlatMatesAorBEnergyClass(apartmani);
            //Console.WriteLine($"{sommaInquiliniApartmani}");
            Console.WriteLine($"Total Flatmates inside A or B energetic class Homes: {GetFlatMatesAorBEnergyClass(apartmani)}");

            Console.WriteLine($"The average of people inside the apartments is: {GetAverageFlatMates(apartmani)}");
            var flatDetailss = GetFlatDetails(apartmani);
            foreach (var item in flatDetailss)
            {
                for (int i = 0; i < item.Addresses.Count; i++)
                {
                    Console.WriteLine($"\t { item.City}, { item.Addresses[i]}");
                } 
                
            }
            Console.ReadKey();
        }

        public static int GetFlatMatesAorBEnergyClass(List<Flat> flats)
        {
            var flatFilter = flats.Where(w => w.Energyclass == EnergyClassType.A || w.Energyclass == EnergyClassType.B).ToList();
            int totalFlatMates = flatFilter.Sum(s => s.FlatMates);
            return totalFlatMates;
        }

        public static double GetAverageFlatMates(List<Flat> flats)
        {
            var averagePeople = flats.Average(a => a.FlatMates);
            return averagePeople;
        }

        //3) di ogni città, nome di città ed elenco di vie degli appartamenti

        public static List<FlatDetail> GetFlatDetails(List<Flat> flats)
        {
            List<FlatDetail> flatDetails = new List<FlatDetail>();
            foreach (var flat in flats)
            {
                FlatDetail apartmentDetail = new FlatDetail();
                apartmentDetail.City = flat.City;
                apartmentDetail.Addresses = flats.Where(w => w.City == flat.City).Select(s => s.Street).ToList();
                flatDetails.Add(apartmentDetail);
               
            }
            return flatDetails;
        }

    }

    class Flat
    {
        public Flat(int squareMeters, string street, string city, int flatMates, EnergyClassType energyclass)
        {
            SquareMeters = squareMeters;
            Street = street;
            City = city;
            FlatMates = flatMates;
            Energyclass = energyclass;
        }

        public int SquareMeters { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int FlatMates { get; set; }
        public EnergyClassType Energyclass { get; set; }
    }
    enum EnergyClassType
    {
        A, B, C, D
    }

    class FlatDetail
    {
        public string City { get; set; }
        public List<string> Addresses { get; set; }
    }
}
