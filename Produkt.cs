
namespace Zadanie4_programowanie2023
{
    public class Produkt : IProdukt
    {
        public string Nazwa { get; set; }

        private decimal cenaNetto;
        public decimal CenaNetto
        {
            get { return cenaNetto; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cena netto nie może być ujemna");
                }
                cenaNetto = value;
            }
        }

        public virtual decimal KategoriiVAT => VATDictionary[KategoriaVAT];
        public decimal CenaBrutto => CenaNetto * (1 + KategoriiVAT / 100);

        private string krajPochodzenia;
        public string KrajPochodzenia
        {
            get => krajPochodzenia;
            set
            {
                if (DostepneKraje.Contains(value))
                    krajPochodzenia = value;
                else
                    throw new ArgumentException("Nieprawidłowy kraj pochodzenia.");
            }
        }

        public string KategoriaVAT { get; set; }

        protected static Dictionary<string, decimal> VATDictionary = new Dictionary<string, decimal>()
    {
        { "0%", 0 },
        { "5%", 5 },
        { "8%", 8 },
        { "23%", 23 }
    };

        private static readonly HashSet<string> DostepneKraje = new HashSet<string>()
    {
        "Norwegia",
        "Belgia",
        "Słowacja",
        "Ukraina",
        "Polska",
        "Czechy",
        "Malta",
        "Wielka Brytania"
    };

        public Produkt(string nazwa, decimal cenaNetto, string kategoriaVAT, string krajPochodzenia)
        {
            Nazwa = nazwa;
            CenaNetto = cenaNetto;
            KategoriaVAT = kategoriaVAT;
            KrajPochodzenia = krajPochodzenia;
        }
    }

    public class ProduktSpozywczy : Produkt
    {
        public ProduktSpozywczy(string nazwa, decimal cenaNetto, string kategoriaVAT, string krajPochodzenia, decimal kalorie)
    : base(nazwa, cenaNetto, kategoriaVAT, krajPochodzenia)
        {
            WalidujKategoriaVAT();
            WalidujKalorie(kalorie);
            Kalorie = kalorie;
            Alergeny = new HashSet<string>();


        }
        public decimal Kalorie { get; set; }
        private void WalidujKalorie(decimal kalorie)
        {
            if (kalorie < 0)
            {
                throw new ArgumentException("Wartość kalorii nie może być ujemna.");
            }
        }

        public HashSet<string> Alergeny { get; set; }

        public List<string> SprawdzAlergeny()
        {
            var przewidywaneAlergeny = PrzewidywaneAlergeny();

            foreach (var alergen in Alergeny)
            {
                if (!przewidywaneAlergeny.Contains(alergen))
                {
                    throw new ArgumentException("Nieprawidłowy alergen: " + alergen);
                }
            }
            return Alergeny.ToList();
        }


        private static HashSet<string> PrzewidywaneAlergeny()
        {
            return new HashSet<string>()
        {
            "Orzechy",
            "Sezam",
            "Mleko",
            "Jajka",
            "Pomidor",
            "Ryby",
            "Pszenica"
        };
        }


        private void WalidujKategoriaVAT()
        {
            HashSet<string> dostepneKategorieVAT = new HashSet<string>()
        {
            "0%",
            "23%"
        };

            if (!dostepneKategorieVAT.Contains(KategoriaVAT))
            {
                throw new ArgumentException("Nieprawidłowa kategoria VAT dla produktu spożywczego.");
            }
        }
    }

    public class ProduktSpozywczyNaWage : ProduktSpozywczy
    {
        public ProduktSpozywczyNaWage(string nazwa, decimal cenaNetto, string kategoriaVAT, string krajPochodzenia, decimal kalorie)
            : base(nazwa, cenaNetto, kategoriaVAT, krajPochodzenia, kalorie)
        {
        }

        public decimal Waga { get; set; }
    }

    public class ProduktSpozywczyPaczka : ProduktSpozywczy
    {
        public ProduktSpozywczyPaczka(string nazwa, decimal cenaNetto, string kategoriaVAT, string krajPochodzenia, decimal kalorie, decimal waga)
    : base(nazwa, cenaNetto, kategoriaVAT, krajPochodzenia, kalorie)
        {
            Waga = waga;
        }

        private decimal waga;

        public decimal Waga
        {
            get { return waga; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Waga nie może być ujemna.");
                }
                waga = value;
            }
        }


    }
    public class ProduktSpozywczyNapoj<T> : ProduktSpozywczyPaczka
    {
        public ProduktSpozywczyNapoj(string nazwa, decimal cenaNetto, string kategoriaVAT, string krajPochodzenia, decimal kalorie, decimal waga, T objetosc)
            : base(nazwa, cenaNetto, kategoriaVAT, krajPochodzenia, kalorie, waga)
        {
            Objetosc = objetosc;
        }

        public T Objetosc { get; set; }
    }

    public class Wielopak<T> : IWielopak<T> where T : IProdukt
    {
        public T Produkt { get; set; }
        public ushort Ilosc { get; set; }
        public decimal CenaNetto { get; set; }

        public decimal CenaBrutto => Produkt.CenaNetto * Ilosc * (1 + Produkt.KategoriiVAT / 100);
        public string KategoriaVAT => Produkt.KategoriaVAT;
        public string KrajPochodzenia => Produkt.KrajPochodzenia;
    }
}
