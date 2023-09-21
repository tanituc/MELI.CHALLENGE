namespace Challenge.Shared.DBModels
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid StatusId { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public float Ammount { get; set; }
        public DateTime? CreatedDate { get; set; } = default(DateTime?);



        //id_pago; v
        //id_usuario; v
        //id del_usuario; v
        //país; v 
        //moneda_local; v
        //total en moneda local; v
        //fecha del pago; v
        //estado del pago; v
        //fecha_creación_de_la_cuenta;

    }
}
