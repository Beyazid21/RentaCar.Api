using FluentValidation.AspNetCore;
using RentACar.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACar.Application.Features.CQRS.Handlers.BannerHandlers;
using RentACar.Application.Features.CQRS.Handlers.CarHandlers;
using RentACar.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentACar.Application.Features.CQRS.Handlers.ContactHandlers;
using RentACar.Application.Features.RepositoryPattern;
using RentACar.Application.Interfaces;
using RentACar.Application.Interfaces.BlogInterfaces;
using RentACar.Application.Interfaces.CarFeaturesInterface;
using RentACar.Application.Interfaces.CarInterfaces;
using RentACar.Application.Interfaces.CarPricingInterface;
using RentACar.Application.Interfaces.RentACarInterfaces;
using RentACar.Application.Interfaces.StatisticsInterfaces;
using RentACar.Application.Interfaces.TagCloudInterfaces;
using RentACar.Application.Services;
using RentACar.Persistence.Context;
using RentACar.Persistence.Repositories;
using RentACar.Persistence.Repositories.BlogRepositories;
using RentACar.Persistence.Repositories.CarFeatureRepositories;
using RentACar.Persistence.Repositories.CarPricingRepositories;
using RentACar.Persistence.Repositories.CarRepositories;
using RentACar.Persistence.Repositories.CommentRepositories;
using RentACar.Persistence.Repositories.RentACarRepositories;
using RentACar.Persistence.Repositories.StatisticsRepositories;
using RentACar.Persistence.Repositories.TagCloudRepositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<RentaCarContext>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler    >();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();


builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();


builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<ICarRepository,CarRepository>();
builder.Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
builder.Services.AddScoped<IBlogRepository,BlogRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(CommentRepository<>));
builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
builder.Services.AddScoped<IRentACarRepository, RentACarRepository>();
builder.Services.AddScoped<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddControllers().AddFluentValidation(x=> {
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
);
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
