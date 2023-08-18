using SchoolExplorer.Domain.Entities;

namespace SchoolExplorer.Domain.Repositories
{
	public interface ISchoolDistrictRepository
	{
		Task<SchoolDistrict> CreateAsync(SchoolDistrict schoolDistrict);
	}
}
