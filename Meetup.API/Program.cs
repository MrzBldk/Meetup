using Meetup.API.Mappers;
using Meetup.BLL.Mappers;
using Meetup.BLL.Services;
using Meetup.BLL.Services.Interfaces;
using Meetup.DAL.Context;
using Meetup.DAL.Entities;
using Meetup.DAL.Repositories;
using Meetup.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0",
        Title = "Meetup API",
        Description = "An ASP.NET Core Web API for managing events"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddAutoMapper(typeof(DtoToViewModelMappingProfile), typeof(ViewModelToDtoMappingProfile),
    typeof(DomainToDtoMappingProfile), typeof(DtoToDomainMappingProfile));
builder.Services.AddDbContext<MeetupContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
builder.Services.AddTransient<IRepository<Entity>, Repository<Entity>>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<ISpeakerService, SpeakerService>();
builder.Services.AddTransient<IOrganizerService, OrganizerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();