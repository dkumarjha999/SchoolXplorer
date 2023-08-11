using AutoMapper;
using SchoolXplorer.Application.Dtos;
using SchoolXplorer.Domain.Entities;

namespace SchoolXplorer.Application.Mappings
{
	public class SchoolDistrictProfile : Profile
	{
		public SchoolDistrictProfile()
		{
			CreateMap<CreateSchoolDistrictDto, SchoolDistrictDto>().ReverseMap();
			CreateMap<SchoolDistrict, CreateSchoolDistrictDto>().ReverseMap();
			CreateMap<SchoolDistrict, SchoolDistrictDto>().ReverseMap();
		}
	}
}
