namespace Web.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton(appSettings);

            services.AddControllersWithViews();

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
