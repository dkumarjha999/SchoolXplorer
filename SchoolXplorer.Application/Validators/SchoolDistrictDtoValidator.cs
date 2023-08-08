using FluentValidation;
using SchoolXplorer.Application.Common;
using SchoolXplorer.Application.Dtos;

namespace SchoolXplorer.Application.Validators
{
	public class SchoolDistrictDtoValidator : AbstractValidator<SchoolDistrictDto>
	{
		public SchoolDistrictDtoValidator()
		{
			RuleFor(sd => sd.Name).NotNull().NotEmpty().WithMessage(ResponseMessages.InvalidName);
			RuleFor(sd => sd.City).NotNull().NotEmpty().WithMessage(ResponseMessages.InvalidCity);
			RuleFor(sd => sd.NumberOfSchools).NotNull().GreaterThan(0).WithMessage(ResponseMessages.InvalidNoOfSchools);
		}
	}
}
