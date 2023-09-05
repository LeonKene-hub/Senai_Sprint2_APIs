using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//adiciona o servico dos controllers
builder.Services.AddControllers();

//Adiciona servico de Jwt Bearer (forma de autenticacao)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //valida quem esta solicitando
        ValidateIssuer = true,

        //valida quem esta recebendo
        ValidateAudience = true,

        //define se o tempo de expiracao sera validado
        ValidateLifetime = true,

        //forma de cripitografia e valida a chave de autenticacao
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

        //valida o tempo de expiracao do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //nome do issuer(de onde esta vindo)
        ValidIssuer = "WebAPI.Filmes.manha",

        //nome do audience (para onde esta indo)
        ValidAudience = "WebAPI.Filmes.manha"
    };
});

//contrutor do Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filme",
        Description = "API para gerenciar filmes - sprint 2 - Backend API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Pedro Henrique Alves",
            Url = new Uri("https://github.com/LeonKene-hub")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autenticaçao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
}
);

var app = builder.Build();

//************************************ configuração do SWAGGER ************************************
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

//************************************ Mapeamento ************************************
//adicioma mapamento dos controles
app.MapControllers();

//adiciona autenticacao 
app.UseAuthentication();

//adiciona autorizacao ad 
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();
