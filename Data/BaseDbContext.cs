namespace Data
{
    public class BaseDbContext : DbContext
    {
        private readonly string _configurationFolder;
        private readonly AppSettings _appSettings;
        // string _configurationFolder = "Application";
        // public BaseDbContext(DbContextOptions<BaseDbContext> options)
        //     : base(options)
        // {
        // }
        public BaseDbContext(AppSettings appSettings, string configurationFolder)
        {
            _appSettings = appSettings;
            _configurationFolder = configurationFolder;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_appSettings.ConnectionString.Default, options =>
            {
                options.MaxBatchSize(100);
                options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

            // var logEnabled = _appSettings.EntityQuery.Enable == true;

            // void LogAction(string log)
            // {
            //     Console.WriteLine(log);
            // }

            // if (logEnabled)
            //     optionsBuilder.LogTo(LogAction, LogLevel.Information, DbContextLoggerOptions.SingleLine);
            // else
            //     optionsBuilder.LogTo(LogAction, LogLevel.Error);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.NoAction;

            var executingAssembly = Assembly.GetExecutingAssembly();
            var filter = $"{executingAssembly.GetName().Name}.Configurations.{_configurationFolder}";

            modelBuilder.ApplyConfigurationsFromAssembly(
                executingAssembly,
                x => x.Namespace.Equals(filter)
            );
        }
    }
}