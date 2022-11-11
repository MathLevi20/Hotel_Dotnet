namespace hotel.Models
{
    public class Parceiro
    {
        public int Id {get;set;}
        public string tipopessoa {get;set;}
        public string atividade {get;set;}

        public virtual ICollection<Fisica>? Fisica { get; set; }
        public virtual ICollection<Juridica> Juridica { get; set; }

    }
}