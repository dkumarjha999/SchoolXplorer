using AutoMapper;
using SchoolExplorer.Application.Dtos;
using SchoolExplorer.Domain.Entities;
using SchoolExplorer.Domain.Repositories;

namespace SchoolExplorer.Application.Services
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

		public async Task<SchoolDistrictDto> CreateAsync(CreateSchoolDistrictDto schoolDistrictDto)
		{
			var schoolDistrictModel = _mapper.Map<SchoolDistrict>(schoolDistrictDto);
			var schoolDistrict = await _schoolDistrictRepository.CreateAsync(schoolDistrictModel);
			return _mapper.Map<SchoolDistrictDto>(schoolDistrict);
		}
	}
}
