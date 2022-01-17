using DNetCoreSix_ApiMinimal.DAO;
using DNetCoreSix_ApiMinimal.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect to PostgreSQL Database
var connectionString1 = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ClienteDb>(options =>
    options.UseNpgsql(connectionString1));

var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.MapPost("/cliente", async(Cliente cliente, ClienteDb db) =>{
    db.cliente.Add(cliente);
    await db.SaveChangesAsync();

    return Results.Created($"/cliente/{cliente.id}", cliente);
});

app.MapGet("/cliente/{id:int}", async(int id, ClienteDb db) => 
{
    return await db.cliente.FindAsync(id)
        is Cliente cliente ? Results.Ok(cliente) : Results.NotFound();
});

app.MapGet("/cliente", async (ClienteDb db) => await db.cliente.ToListAsync());

app.MapPut("/cliente/{id:int}", async(int id, Cliente cliente, ClienteDb db)=>
{
    var updCliente = await db.cliente.FindAsync(id);
    
    if (updCliente is null) return Results.NotFound();

    //Se encontrado, então atualize com as requisições recebida no updCliente.
    updCliente.nome = cliente.nome;
    updCliente.sexo = cliente.sexo;
    updCliente.telefone = cliente.telefone;
    updCliente.pais = cliente.pais;
    updCliente.cidade = cliente.cidade;
    updCliente.estado = cliente.estado;
    updCliente.endereco = cliente.endereco;
    updCliente.cep = cliente.cep;
    await db.SaveChangesAsync();
    return Results.Ok(updCliente);
});

app.MapDelete("/cliente/{id:int}", async(int id, ClienteDb db)=>{

    var delCliente = await db.cliente.FindAsync(id);
    if (delCliente is not null){
        db.cliente.Remove(delCliente);
        await db.SaveChangesAsync();
    }
    return Results.NoContent();
});

app.UseSwaggerUI();
app.Run();
