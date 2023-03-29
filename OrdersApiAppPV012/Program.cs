using OrdersApiAppPV012.Model.Entity;
using OrdersApiAppPV012.Service.ClientService;

var builder = WebApplication.CreateBuilder(args);

// ���������� ������������
builder.Services.AddTransient<IDaoClient, PlugDaoClient>();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

// ������������ �������� � �������� �������

app.MapGet("/client/all", async (HttpContext context, IDaoClient dao) =>
{
    return await dao.GetAllClients();
});

app.MapPost("/client/add", async (HttpContext context, Client client, IDaoClient dao) =>
{
    return await dao.AddClient(client);
});


app.Run();
