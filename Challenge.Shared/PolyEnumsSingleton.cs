using Challenge.Shared.PolyEnums;

namespace Challenge.Shared
{
    public class PolyEnumsSingleton
    {
        public List<Statuses.Status> statuses = new List<Statuses.Status>();
        public List<Countries.Country> countries = new List<Countries.Country>();
        private static PolyEnumsSingleton instance;
        private PolyEnumsSingleton() {
            Statuses    statusPolyEnum = new();
            Countries   countriesPolyEnum = new();
            statuses    = statusPolyEnum.statuses;
            countries   = countriesPolyEnum.countries;
        }
        public static PolyEnumsSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new PolyEnumsSingleton();
            }
            return instance;
        }
    }
}
