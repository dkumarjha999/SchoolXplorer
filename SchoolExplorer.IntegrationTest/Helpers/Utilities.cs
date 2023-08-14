using SchoolExplorer.Infrastructure.MongoData;
namespace SchoolExplorer.IntegrationTest.Helpers
{
	public static class Utilities
	{
		private static List<SchoolDistrict> seedchoolDistricts = GenerateSeedingSchoolDistricts(5);

		public static void ReinitializeDbForTests(IMongoDatabase db, MongoDbSettings mongoDbSettings)
		{
			try
			{
				db.DropCollection(mongoDbSettings.SchoolDistrictsCollectionName);
				var schoolDistricts = db.GetCollection<SchoolDistrict>(mongoDbSettings.SchoolDistrictsCollectionName);
				schoolDistricts.InsertMany(GetSeedingSchoolDistricts());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public static List<SchoolDistrict> GetSeedingSchoolDistricts()
		{
			return seedchoolDistricts;
		}

		public static void ReinitializeDb(CustomWebApplicationFactory<Program> factory)
		{
			using (var scope = factory.Services.CreateScope())
			{
				var scopedServices = scope.ServiceProvider;
				var db = scopedServices.GetRequiredService<IMongoDatabase>();
				var configuration = scopedServices.GetRequiredService<IConfiguration>();
				var mongoDbSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
				ReinitializeDbForTests(db, mongoDbSettings);
			}
		}

		public static List<SchoolDistrict> GenerateSeedingSchoolDistricts(int count)
		{
			var schoolDistricts = new Faker<SchoolDistrict>()
				.RuleFor(sd => sd.Name, f => f.Company.CompanyName())
				.RuleFor(sd => sd.Description, f => f.Lorem.Sentence())
				.RuleFor(sd => sd.City, f => f.Address.City())
				.RuleFor(sd => sd.Superintendent, f => f.Name.FullName())
				.RuleFor(sd => sd.IsPublic, f => f.Random.Bool())
				.RuleFor(sd => sd.NumberOfSchools, f => f.Random.Int(1, 1000))
				.Generate(count);

			return schoolDistricts;
		}
	}
}
