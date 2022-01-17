namespace DNetCoreSix_ApiMinimal.Model
{
    public class ClienteModel
    {
        record Cliente(int id)
        {
            public string nome {get;set;} = default!;
            public string sexo {get;set;} = default!;
            public string telefone {get;set;} = default!;
            public string pais {get;set;} = default!;
            public string cidade {get;set;} = default!;
            public string estado {get;set;} = default!;
            public string endereco {get;set;} = default!;
            public string cep {get;set;} = default!;
        }
    }
}