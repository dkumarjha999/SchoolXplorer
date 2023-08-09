using SchoolXplorer.Application.Dtos;

namespace SchoolXplorer.Application.Services
{
	public interface ISchoolDistrictService
	{
		Task<SchoolDistrictDto> CreateSchoolDistrictAsync(CreateSchoolDistrictDto createSchoolDistrictDto);
	}
}
