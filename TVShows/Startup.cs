using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TVShows.BL;
using TVShows.DAL;
using TVShows.Data;
using TVShows.WEB.Helpers;
using TVShows.WEB.Profiles;
using TVShows.WEB.Services;


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
        services.AddScoped<IUserAuthRepository, UserAuthRepository>();
        services.AddScoped<IUserAuthBL, UserAuthBL>();
        services.AddScoped<IIdentityService, IdentityService>();



        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMaperProfiles());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddControllers();





        services.AddControllers()
               .AddNewtonsoftJson(opt =>
               {
                   opt.SerializerSettings.DateFormatString = "yyyy-MM-dd'T'HH:mm:ss'Z'";
                   opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
               });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });

        // configure strongly typed settings objects
        var appSettingsSection = Configuration.GetSection("AppSettings");
        services.Configure<AppSettings>(appSettingsSection);

        // configure jwt authentication
        var appSettings = appSettingsSection.Get<AppSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings.Secret);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        var configurationSection = Configuration.GetSection("ConnectionStrings:DefaultConnection");
        /*services.AddDbContext<WebTemplateDbContext>(options => options.UseSqlServer(configurationSection.Value));
        services.AddScoped<IWebTemplateDbContext, WebTemplateDbContext>();
        services.AddScoped(provider =>
                new Func<IWebTemplateDbContext>(() => provider.GetService<IWebTemplateDbContext>())
            );*/
        //services.AddScoped<IIdentityService, IdentityService>();

        //RegisterBL(services);
        //RegisterRepositories(services);
        //RegisterAutomapper(services);


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

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}


