namespace hotel.Models
{
    public class Juridica:Pessoa
    {
        public string cnpj {get;set;}
        public string  inscricaoestadual {get;set;}
        public DateOnly  fundacao {get;set;}
        public virtual ICollection<Parceiro> Parceiro { get; set; }
    }
}