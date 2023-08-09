using SchoolXplorer.Domain.Entities;

namespace SchoolXplorer.Domain.Repositories
{
	public interface ISchoolDistrictRepository
	{
		Task<SchoolDistrict> CreateSchoolDistrictAsync(SchoolDistrict schoolDistrict);
	}
}
