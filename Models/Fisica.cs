namespace hotel.Models
{
    public class Fisica : Pessoa
    {
        public string cpf { get; set; }
        public string rg { get; set; }
        public string genero { get; set; }
        public DateOnly nascimento { get; set; }
        public Parceiro? Parceiro { get; set; }
        public virtual ICollection<ReservaHotel> ReservaHotel { get; set; }
    }
}