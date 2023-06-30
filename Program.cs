
namespace Zadanie4_programowanie2023
{
    class Program_Main
    {
        static void Main()
        {

            var produkt = new Produkt("Czekolada", 10.0m, "5%", "Polska");
            var produktSpozywczy = new ProduktSpozywczyNaWage("Mandarynka", 10.0m, "0%", "Słowacja", 1000.0m);

            var produktSpozywczy2 = new ProduktSpozywczyNaWage("Kinder jajko", 10.0m, "0%", "Wielka Brytania", 1000.0m);
            produktSpozywczy.Alergeny.Add("Mleko");

            produktSpozywczy.SprawdzAlergeny();

            Console.WriteLine("Informacje o produkcie spożywczym:");
            Console.WriteLine("Nazwa: " + produktSpozywczy2.Nazwa);
            Console.WriteLine("Cena netto: " + produktSpozywczy2.CenaNetto);
            Console.WriteLine("Kategoria VAT: " + produktSpozywczy2.KategoriiVAT);
            Console.WriteLine("Kraj pochodzenia: " + produktSpozywczy2.KrajPochodzenia);
            Console.WriteLine("Kalorie na 100g: " + (produktSpozywczy2.Kalorie / 100) + " kcal/100g");
            foreach (var alergen in produktSpozywczy.SprawdzAlergeny())
            {
                Console.WriteLine(alergen);
            }

            Console.WriteLine("Informacje o produkcie spożywczym:");
            Console.WriteLine("Nazwa: " + produktSpozywczy.Nazwa);
            Console.WriteLine("Cena netto: " + produktSpozywczy.CenaNetto);
            Console.WriteLine("Kategoria VAT: " + produktSpozywczy.KategoriiVAT);
            Console.WriteLine("Kraj pochodzenia: " + produktSpozywczy.KrajPochodzenia);
            Console.WriteLine("Kalorie na 100g: " + produktSpozywczy.Kalorie);

            var produktNapoj = new ProduktSpozywczyNapoj<uint>("Woda", 5.0m, "23%", "Norwegia", 100.0m, 250, 20000);
            Console.WriteLine("Informacje o produkcie spożywczym:");
            Console.WriteLine("Nazwa: " + produktNapoj.Nazwa);
            Console.WriteLine("Cena netto: " + produktNapoj.CenaNetto);
            Console.WriteLine("Kategoria VAT: " + produktNapoj.KategoriiVAT);
            Console.WriteLine("Kraj pochodzenia: " + produktNapoj.KrajPochodzenia);
            Console.WriteLine("Waga: " + produktNapoj.Waga);
            Console.WriteLine("Objetosc: " + produktNapoj.Objetosc);
            Console.WriteLine("Kalorie na 100g: " + produktNapoj.Kalorie);




            var wielopak = new Wielopak<Produkt>()
            {
                Produkt = produkt,
                Ilosc = 5,
                CenaNetto = 10
            };

            Console.WriteLine($"Nazwa produktu: {wielopak.Produkt.Nazwa}");
            Console.WriteLine($"Cena brutto wielopaku: {wielopak.CenaBrutto}");
            Console.WriteLine($"Kraj: {wielopak.Produkt.KrajPochodzenia}");
            Console.ReadLine();
        }
    }

}
