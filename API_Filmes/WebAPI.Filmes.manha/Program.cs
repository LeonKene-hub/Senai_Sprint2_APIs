var builder = WebApplication.CreateBuilder(args);

//adiciona o servico dos controllers
builder.Services.AddControllers();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//adicioma mapamento dos controles
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
