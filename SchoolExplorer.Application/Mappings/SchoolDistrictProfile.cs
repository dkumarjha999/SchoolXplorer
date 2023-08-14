using AutoMapper;
using SchoolExplorer.Application.Dtos;
using SchoolExplorer.Domain.Entities;

namespace SchoolExplorer.Application.Mappings
{
	public class SchoolDistrictProfile : Profile
	{
		public SchoolDistrictProfile()
		{
			CreateMap<CreateSchoolDistrictDto, SchoolDistrictDto>();
			CreateMap<SchoolDistrictDto, CreateSchoolDistrictDto>();
			CreateMap<CreateSchoolDistrictDto, SchoolDistrict>();
			CreateMap<SchoolDistrict, SchoolDistrictDto>();
			CreateMap<SchoolDistrict, CreateSchoolDistrictDto>();
		}
	}
}
