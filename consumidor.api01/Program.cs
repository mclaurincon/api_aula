using consumidor.api01;
using Flurl;
using Flurl.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

string url = "https://localhost:7068/";
item tarefa = new item();
tarefa.Id = 1;
tarefa.Nome = "pagar contas";
tarefa.Finalizado = true;

item tarefa2 = new item();
tarefa2.Id = 2;
tarefa2.Nome = "lavar louça";
tarefa2.Finalizado = false;


//gerar uma tarefa

string endpoint = url + "api/TarefaItems";

Thread.Sleep(new TimeSpan(0, 0, 5));
//flurl
endpoint.PatchJsonAsync(tarefa);
endpoint.PatchJsonAsync(tarefa2);



//ler lista
IEnumerable<item> listatarefas = await endpoint.GetJsonAsync<IEnumerable<item>>();

foreach (item item in listatarefas)
{
    Console.WriteLine($"A tarefa: {item.Nome} esta finalizado");
}

//deletar um item da lista

//ler lista
