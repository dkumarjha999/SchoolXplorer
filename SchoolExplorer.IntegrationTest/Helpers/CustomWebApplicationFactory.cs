using SchoolExplorer.Infrastructure.MongoData;
namespace SchoolExplorer.IntegrationTest.Helpers
{
	public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
	{
		public IConfiguration Configuration { get; private set; }
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.ConfigureAppConfiguration(config =>
			{
				Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.IntegrationTests.json").Build();
				config.AddConfiguration(Configuration);
			});

			builder.ConfigureServices(services =>
			{
				var mongoDbSettings = Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
				services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(mongoDbSettings?.ConnectionString));
				services.AddSingleton<IMongoDatabase>(sp => sp.GetRequiredService<IMongoClient>().GetDatabase(mongoDbSettings.DatabaseName));

				var sp = services.BuildServiceProvider();
				using var scope = sp.CreateScope();
				var scopedServices = scope.ServiceProvider;
				var db = scopedServices.GetRequiredService<IMongoDatabase>();
				try
				{
					Utilities.ReinitializeDbForTests(db, mongoDbSettings);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			});

			builder.UseEnvironment("IntegrationTests");
		}
	}
}



