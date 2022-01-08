using AutoMapper;
using TVShows.BL;
using TVShows.DAL;
using TVShows.Data;
using TVShows.WEB.Profiles;

namespace TVShows.WEB;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddDbContext<TVShowDbContext>();
        services.AddScoped<IGenreBL, GenreBL>();
        services.AddScoped<IContentBL, ContentBL>();
        services.AddScoped<IUserBL, UserBL>();
        services.AddScoped<IUserShowListBL, UserShowListBL>();
        services.AddScoped<IUserHasRoleBL, UserHasRoleBL>();
        services.AddScoped<IUserHasRoleRepository, UserHasRoleRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IContentRepository, ContentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserShowListRepository, UserShowListRepository>();

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMaperProfiles());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddControllers();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}