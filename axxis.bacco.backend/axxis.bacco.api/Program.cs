using axxis.bacco.api.Policies;
using axxis.bacco.backend.infra.di;
using axxis.bacco.domain.Usuarios.Enums;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("NivelAcessoCliente", policy =>
        policy.Requirements.Add(new TipoUsuarioRequirement(TipoUsuario.Cliente)));

    options.AddPolicy("NivelAcessoAtendenteSalao", policy =>
        policy.Requirements.Add(new TipoUsuarioRequirement(TipoUsuario.Atendente)));

    options.AddPolicy("NivelAcessoAtendenteBalcao", policy =>
        policy.Requirements.Add(new TipoUsuarioRequirement(TipoUsuario.Balcao)));

    options.AddPolicy("NivelAcessoAtendenteCozinha", policy =>
        policy.Requirements.Add(new TipoUsuarioRequirement(TipoUsuario.Cozinha)));

    options.AddPolicy("NivelAcessoAdministrador", policy =>
        policy.Requirements.Add(new TipoUsuarioRequirement(TipoUsuario.Administrador)));

});
builder.Services.AddSingleton<IAuthorizationHandler, TipoUsuarioHandler>();

DependencyInjectionHelper.Configure(builder.Services);

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

app.UseCors(opt =>
{
    opt.AllowAnyOrigin();
    opt.AllowAnyHeader();
    opt.AllowAnyMethod();
});

app.Run();
