using AnnotationServiceBuilder.Annotations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var baseUrl = new Uri("https://jsonplaceholder.typicode.com");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddTransient<SessionHelper>();
builder.Services.AddTransient<AuthHeaderHandler>();

builder.Services.AddScoped<IPostsRepository, PostsRepository>();
builder.Services.AddScoped<IPostsService, PostsService>();

builder.Services.AddRefitClient<IPostsApi>()
.ConfigureHttpClient(c => c.BaseAddress = baseUrl)
.AddHttpMessageHandler<AuthHeaderHandler>();


AnnotationServiceRegistrar.Initialize(Assembly.GetExecutingAssembly());

AnnotationServiceRegistrar.AddSingletonServices(builder.Services);
AnnotationServiceRegistrar.AddScopedServices(builder.Services);
AnnotationServiceRegistrar.AddTransientServices(builder.Services);
AnnotationServiceRegistrar.AddRefitClients(builder.Services, "https://jsonplaceholder.typicode.com"); // Replace with your API base URL

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
