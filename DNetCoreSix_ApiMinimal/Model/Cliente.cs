namespace DNetCoreSix_ApiMinimal.Model
{
    public record Cliente
    {
        public int id {get;set;}
        public string? nome {get;set;}
        public string? sexo {get;set;}
        public string? telefone {get;set;}
        public string? pais {get;set;}
        public string? cidade {get;set;}
        public string? estado {get;set;}
        public string? endereco {get;set;}
        public string? cep {get;set;}
    }
}