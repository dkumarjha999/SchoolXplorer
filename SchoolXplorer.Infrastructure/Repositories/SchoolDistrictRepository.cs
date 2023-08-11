using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SchoolXplorer.Domain.Entities;
using SchoolXplorer.Domain.Repositories;
using SchoolXplorer.Infrastructure.MongoData;

namespace SchoolXplorer.Infrastructure.Repositories
{
	public class SchoolDistrictRepository : ISchoolDistrictRepository
	{
		private readonly IMongoCollection<SchoolDistrict> _schoolDistricts;
		public SchoolDistrictRepository(IMongoDatabase mongoDatabase, IOptions<MongoDbSettings> mongoDbSettings)
		{
			_schoolDistricts = mongoDatabase.GetCollection<SchoolDistrict>(mongoDbSettings.Value.SchoolDistrictsCollectionName);
		}

		public async Task<SchoolDistrict> CreateSchoolDistrictAsync(SchoolDistrict schoolDistrict)
		{
			await _schoolDistricts.InsertOneAsync(schoolDistrict);
			return schoolDistrict;
		}
	}
}
