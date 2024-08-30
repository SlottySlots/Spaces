using Blazored.SessionStorage;
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
using SlottyMedia.Database.Helper;
using SlottyMedia.Database.Repository.CommentRepo;
using SlottyMedia.Database.Repository.FollowerUserRelatioRepo;
using SlottyMedia.Database.Repository.ForumRepo;
using SlottyMedia.Database.Repository.PostRepo;
using SlottyMedia.Database.Repository.RoleRepo;
using SlottyMedia.Database.Repository.SearchRepo;
using SlottyMedia.Database.Repository.UserLikePostRelationRepo;
using SlottyMedia.Database.Repository.UserRepo;
using SlottyMedia.DatabaseSeeding;
using SlottyMedia.LoggingProvider;
using Supabase;


// Early init of NLog to allow startup and exception logging, before host is built
Logging<Program> logger = new();
logger.LogInfo("Starting application");
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    logger.LogInfo("Adding services to the container");
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();

    builder.Services.AddBlazoredSessionStorage();

    // NLog: Setup NLog for Dependency injection
    logger.LogInfo("Setting up NLog for Dependency injection");
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add Supabase
    logger.LogInfo("Adding Supabase to the container");
    builder.Services.AddSingleton(_ =>
        InitializeSupabaseClient.GetSupabaseClient());

    //Helpers
    logger.LogInfo("Adding Helpers to the container");
    builder.Services.AddSingleton<DaoHelper>();
    builder.Services.AddSingleton<DatabaseRepositroyHelper>();

    // Repositories
    logger.LogInfo("Adding Repositories to the container");
    builder.Services.AddSingleton<IUserRepository, UserRepository>();
    builder.Services.AddSingleton<IPostRepository, PostRepository>();
    builder.Services.AddSingleton<IForumRepository, ForumRepository>();
    builder.Services.AddSingleton<ITopForumRepository, TopForumRepository>();
    builder.Services.AddSingleton<IFollowerUserRelationRepository, FollowerUserRelationRepository>();
    builder.Services.AddSingleton<IUserLikePostRelationRepostitory, UserLikePostRelationRepostitory>();
    builder.Services.AddSingleton<IUserSeachRepository, UserSearchRepository>();
    builder.Services.AddSingleton<IForumSearchRepository, ForumSearchRepository>();
    builder.Services.AddSingleton<IRoleRepository, RoleRepository>();
    builder.Services.AddSingleton<ICommentRepository, CommentRepository>();


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

    // Services
    logger.LogInfo("Adding Services to the container");
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IPostService, PostService>();
    builder.Services.AddScoped<IForumService, ForumService>();
    builder.Services.AddScoped<ICookieService, CookieService>();
    builder.Services.AddScoped<IAuthService, AuthService>(); // Scoped
    builder.Services.AddScoped<ISignupService, SignupServiceImpl>();
    builder.Services.AddScoped<ISearchService, SearchService>();
    builder.Services.AddScoped<IForumService, ForumService>();
    builder.Services.AddScoped<ILikeService, LikeService>();
    builder.Services.AddScoped<ICommentService, CommentService>();

    // Viewmodel
    logger.LogInfo("Adding Viewmodels to the container");
    builder.Services.AddScoped<ISignupFormVm, SignupFormVmImpl>();
    builder.Services.AddScoped<ISignInFormVm, SignInFormVmImpl>();
    builder.Services.AddScoped<IMainLayoutVm, MainLayoutVmImpl>();
    builder.Services.AddScoped<ISpacesVm, SpacesVmImpl>();
    builder.Services.AddScoped<ISpacesCardVm, SpacesCardVmImpl>();
    builder.Services.AddScoped<IPostSubmissionFormVm, PostSubmissionFormVmImpl>();
    builder.Services.AddScoped<IHomePageVm, HomePageVmImpl>();
    builder.Services.AddScoped<IAuthVmImpl, AuthVmImpl>();
    builder.Services.AddScoped<IUserVmImpl, UserVmImpl>();
    builder.Services.AddScoped<IPostPageVm, PostPageVmImpl>();
    builder.Services.AddScoped<ICommentSubmissionFormVm, CommentSubmissionFormVmImpl>();


    var app = builder.Build();

    // Seed the database
    using (var scope = app.Services.CreateScope())
    {
        try
        {
            logger.LogInfo("Starting to seed the database");
            var seeder = scope.ServiceProvider.GetRequiredService<Client>();
            var daoHelper = scope.ServiceProvider.GetRequiredService<DaoHelper>();
            var databaseRepositroyHelper = scope.ServiceProvider.GetRequiredService<DatabaseRepositroyHelper>();
            Seeding seeding = new(seeder, daoHelper, databaseRepositroyHelper);
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