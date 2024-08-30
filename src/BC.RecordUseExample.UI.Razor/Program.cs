using BC.RecordUseExample.Backend.App;
using BC.RecordUseExample.Backend.App.Services;
using BC.RecordUseExample.Backend.Domain.Commands;
using BC.RecordUseExample.Backend.Infrastructure;
using BC.RecordUseExample.Backend.Infrastructure.Setup;
using BC.RecordUseExample.UI.Razor.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    string[] supportedCultures = ["en", "es"];
    options//.SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddRazorPages().AddViewLocalization();
builder.Services.AddSqlPersistence(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddScoped<LanguageService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Get all implementations of ICommandHandler and add them to the DI
var types = typeof(SystemCommands).Assembly.DefinedTypes;
var handlers = types
    .Where(x => !x.IsAbstract && x.IsClass && !x.IsInterface && x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
    .ToList();

handlers.ForEach((handler) =>
{
    foreach (var implementedInterface in handler.ImplementedInterfaces)
    {
        builder.Services.AddScoped(implementedInterface, handler);
    }
});

builder.Services.AddScoped<SystemCommands>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // Run migrations locally
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<SqlDbContext>();
    db.Database.Migrate();
}


app.UseRequestLocalization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
