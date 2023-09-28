namespace Challenge.ExternalServices
{
    using Challenge.ToolKit;
    using System.Text;
    using System.Text.Json;
    public class CurrencyConverter
    {
        public static double ConvertARStoUSD(double aRSAmmount) =>  Math.Round(aRSAmmount / GetUSDPrice(), 2);
        public static double ConvertARStoUSD(double aRSAmmount, double uSDPrice) =>  Math.Round(aRSAmmount / uSDPrice, 2);
        public static double ConvertUSDtoARS(double uSDAmmount) =>  Math.Round(uSDAmmount * GetUSDPrice(), 2);
        public static double GetUSDPrice() {
            string url = "https://www.dolarsi.com/api/api.php?type=dolar";
            byte[] responseArray = (new WebRequestAdapter()).GetRemoteData(url);
            string responseString = "{ \"casas\":" + Encoding.UTF8.GetString(responseArray) + "}";
            DolarsiResponse response = JsonSerializer.Deserialize<DolarsiResponse>(responseString);
            List<Casa> casas = response.casas.ConvertAll(container => container.casa);
            Casa dolarOficial = casas.First(x => x.nombre == "Oficial");
            dolarOficial.venta = dolarOficial.venta.Substring(0, dolarOficial.venta.Length - 1).Replace(",", ".");
            return Math.Round(double.Parse(dolarOficial.venta), 2);
        }
    }
    public class DolarsiResponse
    {
        public List<CasaContainer> casas { get; set; }
    }

    public class CasaContainer
    {
        public Casa casa { get; set; }
    }

    public class Casa
    {
        public string venta { get; set; }
        public string nombre { get; set; }
    }
}
