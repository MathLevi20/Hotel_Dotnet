namespace hotel.Models
{
    public class ReservaHotel
    {
        public int id {get;set;}
        public string numeroreserva {get;set;}
        public int valor {get;set;}
        public DateOnly datareserva {get;set;}
        public virtual ICollection<Fisica> Fisica { get; set; }

    }
}