using Api_Farmacias.Mapping;
using Api_Farmacias.Repositorio;
using Api_Farmacias.Repositorio.Interface;
using Api_Farmacias.Database;
using Api_Farmancias.Repositorio;
using Api_Farmacias.Repositorio.InterFace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(FarmaciaMapping));
builder.Services.AddAutoMapper(typeof(FarmaciaMapping));
builder.Services.AddDbContext<Appdbcontext>();
builder.Services.AddScoped<IFarmaciaRepository,FarmaciaRepository>();
builder.Services.AddScoped<ILocalizacaoRepository,LocalizacaoRepository>();
builder.Services.AddScoped<IN_TelefoneRepository,N_TelefoneRepository>();
builder.Services.AddScoped<IDirecaoRepository,DirecaoRepository>();
builder.Services.AddScoped<ILocalizacaoRepository,LocalizacaoRepository>();
builder.Services.AddScoped<IN_TelefoneRepository,N_TelefoneRepository>();
builder.Services.AddScoped<IDirecaoRepository,DirecaoRepository>();
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

