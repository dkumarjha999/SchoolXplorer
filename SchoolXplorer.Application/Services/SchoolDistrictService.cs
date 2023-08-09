using SchoolXplorer.Application.Dtos;
using SchoolXplorer.Domain.Repositories;

namespace SchoolXplorer.Application.Services
{
	public class SchoolDistrictService : ISchoolDistrictService
	{
		private readonly ISchoolDistrictRepository _schoolDistrictRepository;
		public SchoolDistrictService(ISchoolDistrictRepository schoolDistrictRepository)
		{
			_schoolDistrictRepository = schoolDistrictRepository;
		}

		public async Task<SchoolDistrictDto> CreateSchoolDistrictAsync(CreateSchoolDistrictDto schoolDistrictDto)
		{
			throw new NotImplementedException();
		}
	}
}
