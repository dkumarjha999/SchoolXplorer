using AutoMapper;
using SchoolXplorer.Application.Dtos;
using SchoolXplorer.Domain.Entities;
using SchoolXplorer.Domain.Repositories;

namespace SchoolXplorer.Application.Services
{
	public class SchoolDistrictService : ISchoolDistrictService
	{
		private readonly ISchoolDistrictRepository _schoolDistrictRepository;
		private readonly IMapper _mapper;
		public SchoolDistrictService(ISchoolDistrictRepository schoolDistrictRepository, IMapper mapper)
		{
			_schoolDistrictRepository = schoolDistrictRepository;
			_mapper = mapper;
		}

		public async Task<SchoolDistrictDto> CreateSchoolDistrictAsync(CreateSchoolDistrictDto schoolDistrictDto)
		{
			var schoolDistrictModel = _mapper.Map<SchoolDistrict>(schoolDistrictDto);
			var schoolDistrict = await _schoolDistrictRepository.CreateSchoolDistrictAsync(schoolDistrictModel);
			return _mapper.Map<SchoolDistrictDto>(schoolDistrict);
		}
	}
}
