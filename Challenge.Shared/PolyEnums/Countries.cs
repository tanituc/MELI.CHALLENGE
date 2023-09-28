namespace Challenge.Shared.PolyEnums
{
    public class Countries
    {
        public List<Country> countries { get; }
        public Countries()
        {
            countries = new List<Country>();
            countries.Add(new Country(Guid.Parse("9ED9C307-99E6-44AC-8356-6567878698BD"), "Argentina", "ARG", "ARS"));
            countries.Add(new Country(Guid.Parse("56DE6BD8-EFF7-4A81-8C65-3C1F248AC908"), "Estados Unidos", "USA", "USD"));
        }

        public class Country
        {
            public Guid Id;
            public string Name;
            public string Alias;
            public string Currency;
            public Country(Guid id, string name, string alias, string currency)
            {
                Id = id;
                Name = name;
                Alias = alias;
                Currency = currency;
            }
        }
    }
}
