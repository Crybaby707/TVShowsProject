using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
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
        services.AddLocalization(o =>
        {
            // We will put our translations in a folder called Resources
            o.ResourcesPath = "Resources";
        });
        services.AddMvc();
        services.AddMvc(options => options.EnableEndpointRouting = false);



        services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

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
        services.AddScoped<IContentGenreBL, ContentGenreBL>();
        services.AddScoped<IContentGenreRepository, ContentGenreRepository>();
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


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseStaticFiles();

        IList<CultureInfo> supportedCultures = new List<CultureInfo>
        {
        new CultureInfo("en-US"),
        new CultureInfo("uk-UA"),
        new CultureInfo("de-DE")
        };
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en-US"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });

        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });




        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

      /*  var supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("uk-UK")
        };


        var requestLocalizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures

        };*/


        app.UseHttpsRedirection();
        //app.UseRequestLocalization(requestLocalizationOptions); 

        app.UseRouting(); 


        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}


