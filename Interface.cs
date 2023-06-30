namespace Zadanie4_programowanie2023
{
    public interface IProdukt
    {
        string Nazwa { get; set; }
        decimal CenaNetto { get; set; }
        decimal KategoriiVAT { get; }
        decimal CenaBrutto { get; }
        string KategoriaVAT { get; }
        string KrajPochodzenia { get; set; }
    }

    public interface IWielopak<T> where T : IProdukt
    {
        T Produkt { get; set; }
        ushort Ilosc { get; set; }
        decimal CenaNetto { get; set; }
        decimal CenaBrutto { get; }
        string KategoriaVAT { get; }
        string KrajPochodzenia { get; }
    }
}
