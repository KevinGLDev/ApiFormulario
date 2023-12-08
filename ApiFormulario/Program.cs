var builder = WebApplication.CreateBuilder(args);
var _MyCors = "MyCors";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _MyCors, cors =>
    {
        cors.SetIsOriginAllowed(origin => new Uri(origin).Host=="localhost").AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddControllers();
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

app.UseCors(_MyCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
