namespace Web.Configurations;
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

        services.AddScoped<AppDbContext>();

        services.AddScoped<ITarefaRepository, TarefaRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IOpcaoTelaUsuarioRepository, OpcaoTelaUsuarioRepository>();
        services.AddScoped<IOpcaoRepository, OpcaoRepository>();
        services.AddScoped<ITelaRepository, TelaRepository>();

        services.AddScoped<IOpcaoTelaUsuarioService, OpcaoTelaUsuarioService>();
        services.AddScoped<ITarefaService, TarefaService>();
        services.AddScoped<IOpcaoService, OpcaoService>();
        services.AddScoped<ITelaService, TelaService>();
    }
}