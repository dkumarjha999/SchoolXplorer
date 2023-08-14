using FluentValidation;
using SchoolExplorer.Application.Common;
using SchoolExplorer.Application.Dtos;

namespace SchoolExplorer.Application.Validators
{
	public class CreateSchoolDistrictDtoValidator : AbstractValidator<CreateSchoolDistrictDto>
	{
		public CreateSchoolDistrictDtoValidator()
		{
			RuleFor(sd => sd.Name).NotNull().NotEmpty().WithMessage(ResponseMessages.InvalidName);
			RuleFor(sd => sd.City).NotNull().NotEmpty().WithMessage(ResponseMessages.InvalidCity);
			RuleFor(sd => sd.NumberOfSchools).NotNull().GreaterThan(0).WithMessage(ResponseMessages.InvalidNoOfSchools);
		}
	}
}
