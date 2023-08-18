using AutoMapper;
using SchoolExplorer.Application.Dtos;
using SchoolExplorer.Domain.Entities;

namespace SchoolExplorer.Application.Mappings
{
	public class SchoolDistrictProfile : Profile
	{
		public SchoolDistrictProfile()
		{
			CreateMap<CreateSchoolDistrictDto, SchoolDistrictDto>().ReverseMap();
			CreateMap<CreateSchoolDistrictDto, SchoolDistrict>().ReverseMap();
			CreateMap<SchoolDistrict, SchoolDistrictDto>();
		}
	}
}
