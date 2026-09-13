using Application.Abstractions;
using Application.Brand.UseCases;
using Application.Product.DTOs;
using Application.Product.Mapper;
using Application.Product.UseCases;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Conexion
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
// Agregar Contexto
builder.Services.AddDbContext<StoreFsContext>(options =>
{
    options.UseSqlServer(connection);
});


// Inyeccion de Dependencia
builder.Services.AddTransient<IRepository<BrandEntity>, BrandRepository>();
builder.Services.AddTransient<IUseCase<BrandEntity>, BrandUseCase>();

builder.Services.AddTransient<IReadRepository<ProductEntity>, ProductRepository>();
builder.Services.AddTransient<IReadUseCase<ProductDto, ProductEntity>, ProductUseCase>();
    
builder.Services.AddTransient<ICreateUseCase<ProductDto, ProductEntity>, CreateProductUseCase>();
builder.Services.AddTransient<IDeleteUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IUpdateUseCase<ProductDto, ProductEntity>, UpdateProductUseCase>();

builder.Services.AddTransient<ICreateRepository<ProductEntity>, ProductRepository>();
builder.Services.AddTransient<IUpdateRepository<ProductEntity>, ProductRepository>();
builder.Services.AddTransient<IDeleteRepository, ProductRepository>();

builder.Services.AddTransient<IMapper<ProductEntity, ProductDto>, ProductEntityToDtoMapper>();
builder.Services.AddTransient<IMapper<ProductDto, ProductEntity>, ProductDtoToEntityMapper>();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Generacion de las herramientas de swagger necesarias

// Cors
const string FrontendPolicy = "FrontendPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: FrontendPolicy, policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(FrontendPolicy);

// Brands
app.MapGet("brand", async (IUseCase<BrandEntity> useCase) =>
{
    return await useCase.GetAllAsync();
}).WithName("getBrand");

app.MapPost("brand", async(IUseCase<BrandEntity> useCase, BrandEntity brand) =>
{
    await useCase.AddAsync(brand);
    return Results.Created();
}).WithName("addBrand")
  .Produces(StatusCodes.Status201Created);

app.MapPut("brand/{id}", async (int id, BrandEntity brand, IUseCase<BrandEntity> useCase) =>
{
    try
    {
        //var name = body.RootElement.GetProperty("name").GetString();
        var brandEntity = new BrandEntity(id, brand.Name);

        await useCase.UpdateAsync(brandEntity);

    }catch(Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }

    return Results.NoContent();
}).Produces(StatusCodes.Status204NoContent)
  .WithName("updateBrand");

app.MapDelete("brand/{id}", async (int id, IUseCase<BrandEntity> useCase) =>
{
    try
    {
        await useCase.DeleteAsync(id);
    }
    catch (Exception ex) 
    {
        return Results.BadRequest(ex.Message);
    }
    return Results.NoContent();
})  .Produces(StatusCodes.Status204NoContent)
    .WithName("deleteBrand");

// Product
app.MapGet("/product", async (IReadUseCase<ProductDto, ProductEntity> useCase) =>
{
    return await useCase.GetAllAsync();
}).WithName("getProduct");

app.MapGet("/product/{id}", async (int id, IReadUseCase<ProductDto, ProductEntity> useCase) =>
{
    try
    {
        var product = await useCase.GetByIdAsync(id);
        if (product == null) return Results.NotFound();
        return Results.Ok(product);

    }
    catch (Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
}).WithName("getProductById")
.Produces<ProductDto>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapPost("/product", async (ProductDto dto, ICreateUseCase<ProductDto, ProductEntity> useCase) =>
{
    try
    {
        await useCase.AddAsync(dto);
        return Results.Created();
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch(Exception ex)
    {
        return Results.InternalServerError(ex.Message);
    }

}).WithName("addProduct")
  .Produces(StatusCodes.Status201Created)
  .Produces(StatusCodes.Status400BadRequest)
  .Produces(StatusCodes.Status500InternalServerError);

app.MapPut("/product/{id}", async (int id, ProductDto dto, IUpdateUseCase<ProductDto, ProductEntity> useCase) =>
{
    try
    {
        await useCase.UpdateAsync(dto, id);
        return Results.NoContent();

    }catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (KeyNotFoundException ex)
    {
        return Results.NotFound(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.InternalServerError(ex.Message);
    }
}).WithName("updateProduct")
  .Produces(StatusCodes.Status204NoContent)
  .Produces(StatusCodes.Status400BadRequest)
  .Produces(StatusCodes.Status404NotFound)
  .Produces(StatusCodes.Status500InternalServerError);

app.MapDelete("/product/{id}", async (int id, IDeleteUseCase useCase) =>
{
    try
    {
        await useCase.DeleteAsync(id);
        return Results.NoContent();
    }
    catch (KeyNotFoundException ex)
    {
        return Results.NotFound(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.InternalServerError(ex.Message);
    }
}).WithName("deleteProduct")
  .Produces(StatusCodes.Status204NoContent)
  .Produces(StatusCodes.Status404NotFound)
  .Produces(StatusCodes.Status500InternalServerError); ;

// Test
app.MapGet("/test", () =>
{
    return "online";
}).WithName("test");

app.Run();

