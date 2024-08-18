using NLog;
using NLog.Web;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Components;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.DatabaseSeeding;
using SlottyMedia.LoggingProvider;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = Logging.Instance;
logger.LogInfo("Starting application");
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    logger.LogInfo("Adding services to the container");
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();
    // NLog: Setup NLog for Dependency injection
    logger.LogInfo("Setting up NLog for Dependency injection");
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add Supabase
    logger.LogInfo("Adding Supabase to the container");
    builder.Services.AddSingleton(_ =>
        InitializeSupabaseClient.GetSupabaseClient());

    // Database
    logger.LogInfo("Adding Database to the container");
    builder.Services.AddSingleton<IDatabaseActions, DatabaseActions>();

    // Daos
    logger.LogInfo("Adding Daos to the container");
    builder.Services.AddSingleton<UserDao>();
    builder.Services.AddSingleton<PostsDao>();
    builder.Services.AddSingleton<ForumDao>();
    builder.Services.AddSingleton<CommentDao>();
    builder.Services.AddSingleton<FollowerUserRelationDao>();
    builder.Services.AddSingleton<UserLikePostRelationDao>();

    // DtOs
    logger.LogInfo("Adding Dtos to the container");
    builder.Services.AddSingleton<UserDto>();
    builder.Services.AddSingleton<PostDto>();
    builder.Services.AddSingleton<ForumDto>();
    builder.Services.AddSingleton<FriendsOfUserDto>();
    builder.Services.AddSingleton<ProfilePicDto>();
    builder.Services.AddSingleton<SearchDto>();

    // Viewmodel
    logger.LogInfo("Adding Viewmodels to the container");
    builder.Services.AddScoped<ISignupFormVm, SignupFormVmImpl>();
    builder.Services.AddScoped<ISignInFormVm, SignInFormVmImpl>();
    builder.Services.AddScoped<IPostSubmissionFormVm, PostSubmissionFormVmImpl>();

    // Services
    logger.LogInfo("Adding Services to the container");
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IPostService, PostService>();
    builder.Services.AddScoped<ICookieService, CookieService>();
    builder.Services.AddScoped<IAuthService, AuthService>(); // Scoped
    builder.Services.AddScoped<ISignupService, SignupServiceImpl>();
    builder.Services.AddScoped<ISearchService, SearchService>();


    var app = builder.Build();

    // Seed the database
    using (var scope = app.Services.CreateScope())
    {
        try
        {
            logger.LogInfo("Starting to seed the database");
            var seeder = scope.ServiceProvider.GetRequiredService<IDatabaseActions>();
            Seeding seeding = new(seeder);
            await seeding.Seed();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Database seeding failed.");
        }
    }

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
}
catch (Exception ex)
{
    // NLog: catch setup errors
    logger.LogError(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}