namespace Challenge.Shared.PolyEnums
{
    public class Statuses
    {
        public List<Status> statuses { get; }
        public Statuses()
        {
            statuses = new List<Status>();
            statuses.Add(new Status(Guid.Parse("90C3DBAB-D4FE-4ABC-A734-BFDBD380209C"), "Pending"));
            statuses.Add(new Status(Guid.Parse("25D6FCE0-2C05-4E9E-9A9A-EB6243AB6B3A"), "Rejected"));
            statuses.Add(new Status(Guid.Parse("D221401B-F0F5-43D6-A94B-AA4A2262668A"), "Pending"));
        }
       
        public class Status
        {
            public Guid     Id      { get; }
            public string   Value   { get; }
            public Status(Guid key, string value)
            {
                Id      = key;
                Value   = value;
            }
        }
    }

}
