using Common.Carter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter(new DynamicAssemblyCatalog(typeof(Program).Assembly));
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder
    .Services.AddMarten(opts =>
    {
        var connectionStr =
            builder.Configuration.GetConnectionString("Database")
            ?? throw new Exception("Database connection string is not set");

        opts.Connection(connectionStr);
    })
    .UseLightweightSessions();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapCarter();

app.Run();
