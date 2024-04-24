using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Test;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var modelBuilder = new ODataModelBuilder();

var customerType = modelBuilder.EntityType<Customer>();
customerType.HasKey(c => c.Id);
customerType.ComplexProperty(c => c.Name);


Type localizableStringType = typeof(LocalizableString);
ComplexTypeConfiguration localizableStringConfiguration = modelBuilder.AddComplexType(localizableStringType);
localizableStringConfiguration.AddDynamicPropertyDictionary(localizableStringType.GetProperty(nameof(LocalizableString.ExtendedProperties)));

modelBuilder.EntitySet<Customer>("Customers");

builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()));

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
