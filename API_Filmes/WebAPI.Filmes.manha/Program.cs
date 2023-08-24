var builder = WebApplication.CreateBuilder(args);

//adiciona o servico dos controllers
builder.Services.AddControllers();
//contrutor do Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Aqui comeca a configuracao do SWAGGER

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//finaliza a configuracao do SWAGGER

//adicioma mapamento dos controles
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
