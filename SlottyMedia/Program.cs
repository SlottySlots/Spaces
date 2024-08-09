using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Components;
using SlottyMedia.Database.Models;
using SlottyMedia.Database;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Supabase
var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");
if (url is null || key is null) throw new Exception("Supabase settings not found");
builder.Services.AddSingleton(_ =>
    new Client(
        url, key,
        new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        }));


// Database
builder.Services.AddSingleton<IDatabaseActions, DatabaseActions>();

// Model
builder.Services.AddSingleton<UserDto>();

// Viewmodel
builder.Services.AddSingleton<ICounterVm, CounterVm>();


// Services
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddScoped<ICookieService, CookieService>();


builder.Services.AddScoped<IAuthService, AuthService>();  // Scoped
builder.Services.AddScoped<ISignupService, SignupServiceImpl>();
builder.Services.AddScoped<ISignupFormVm, SignupFormVmImpl>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
