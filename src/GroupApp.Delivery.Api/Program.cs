using GroupApp.Delivery.Application.Extensions;
using GroupApp.Delivery.Infrastructure.Database.Postgres.Extensions;
using GroupApp.Delivery.Infrastructure.Kafka.Extensions;
using GroupApp.Delivery.Infrastructure.Kafka.Settings;

var builder = WebApplication.CreateBuilder(args);

var application = builder.Configuration;
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddApplication();
services.AddKafka();
services.AddDatabase();

services.Configure<OrderSettings>(application.GetSection("OrderSettings"));

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
