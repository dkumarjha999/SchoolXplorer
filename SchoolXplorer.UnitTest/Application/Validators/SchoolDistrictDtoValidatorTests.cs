global using FluentValidation.TestHelper;
using SchoolXplorer.Application.Dtos;
using SchoolXplorer.Application.Validators;

namespace SchoolXplorer.UnitTest.Application.Validators
{
	public class SchoolDistrictDtoValidatorTests
	{
		private SchoolDistrictDtoValidator _validator;
		private Fixture _fixture;
		public SchoolDistrictDtoValidatorTests()
		{
			_validator = new SchoolDistrictDtoValidator();
			_fixture = new Fixture();
		}
		[Fact]
		public void Validator_WhenNameIsNull_ShouldReturnNameError()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<SchoolDistrictDto>();
			schoolDistrictDto.Name =null;
			//Act
			var result = _validator.TestValidate(schoolDistrictDto);
			//Assert
			result.ShouldHaveValidationErrorFor(sd => sd.Name);
		}

		[Fact]
		public void Validator_WhenNameIsEmpty_ShouldReturnNameError()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<SchoolDistrictDto>();
			schoolDistrictDto.Name =string.Empty;
			//Act
			var result = _validator.TestValidate(schoolDistrictDto);
			//Assert
			result.ShouldHaveValidationErrorFor(sd => sd.Name);
		}

		[Fact]
		public void Validator_WhenCityIsNull_ShouldReturnCityError()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<SchoolDistrictDto>();
			schoolDistrictDto.City=null;
			//Act
			var result = _validator.TestValidate(schoolDistrictDto);
			//Assert
			result.ShouldHaveValidationErrorFor(sd => sd.City);
		}

		[Fact]
		public void Validator_WhenCityIsEmpty_ShouldReturnCityError()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<SchoolDistrictDto>();
			schoolDistrictDto.City=string.Empty;
			//Act
			var result = _validator.TestValidate(schoolDistrictDto);
			//Assert
			result.ShouldHaveValidationErrorFor(sd => sd.City);
		}

		[Fact]
		public void Validator_WhenNumberOfSchoolsIsNotGreaterThanZero_ShouldReturnNumberOfSchoolsError()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<SchoolDistrictDto>();
			schoolDistrictDto.NumberOfSchools = 0;
			//Act
			var result = _validator.TestValidate(schoolDistrictDto);
			//Assert
			result.ShouldHaveValidationErrorFor(sd => sd.NumberOfSchools);
		}

		[Fact]
		public void Validator_WhenDtoIsValid_ShouldNotHaveAnyErrors()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<SchoolDistrictDto>();
			//Act
			var result = _validator.TestValidate(schoolDistrictDto);
			//Assert
			result.ShouldNotHaveAnyValidationErrors();
		}
	}
}
