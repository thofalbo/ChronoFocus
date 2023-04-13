using Microsoft.Extensions.DependencyInjection;

namespace Web.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton(appSettings);

            services.AddControllersWithViews();

            var key = Encoding.ASCII.GetBytes(appSettings.Chave.Segredo);

            services.AddAuthentication(x =>
            {	
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
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

            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();

            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<ITarefaService, TarefaService>();
        }
    }
}
