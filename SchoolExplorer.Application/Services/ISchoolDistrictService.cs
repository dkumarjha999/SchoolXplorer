using SchoolExplorer.Application.Dtos;

namespace SchoolExplorer.Application.Services
{
	public interface ISchoolDistrictService
	{
		Task<SchoolDistrictDto> CreateAsync(CreateSchoolDistrictDto createSchoolDistrictDto);
	}
}
