namespace Challenge.Shared.DBModels
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
