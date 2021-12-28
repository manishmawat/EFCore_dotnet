namespace EFCore_dotnet.Data
{
    public static class Extensions
    {
        public static void CreateDbIfNotExist(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<EmployeeContext>();
                if (context.Database.EnsureCreated())
                {
                    DbInitializer.Initialize(context);
                }
            }
        }
    }
}
