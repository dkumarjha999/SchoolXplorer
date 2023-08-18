namespace SchoolExplorer.UnitTest.Application.Validators
{
	public class CreateSchoolDistrictDtoValidatorTests
	{
		private readonly CreateSchoolDistrictDtoValidator _validator;
		private readonly Fixture _fixture;
		public CreateSchoolDistrictDtoValidatorTests()
		{
			_validator = new CreateSchoolDistrictDtoValidator();
			_fixture = new Fixture();
		}
		[Fact]
		public void Validator_WhenNameIsNull_ShouldReturnNameError()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<CreateSchoolDistrictDto>();
			schoolDistrictDto.Name = null;
			//Act
			var result = _validator.TestValidate(schoolDistrictDto);
			//Assert
			result.ShouldHaveValidationErrorFor(sd => sd.Name);
		}

		[Fact]
		public void Validator_WhenNameIsEmpty_ShouldReturnNameError()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<CreateSchoolDistrictDto>();
			schoolDistrictDto.Name = string.Empty;
			//Act
			var result = _validator.TestValidate(schoolDistrictDto);
			//Assert
			result.ShouldHaveValidationErrorFor(sd => sd.Name);
		}

		[Fact]
		public void Validator_WhenCityIsNull_ShouldReturnCityError()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<CreateSchoolDistrictDto>();
			schoolDistrictDto.City = null;
			//Act
			var result = _validator.TestValidate(schoolDistrictDto);
			//Assert
			result.ShouldHaveValidationErrorFor(sd => sd.City);
		}

		[Fact]
		public void Validator_WhenCityIsEmpty_ShouldReturnCityError()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<CreateSchoolDistrictDto>();
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
			var schoolDistrictDto = _fixture.Create<CreateSchoolDistrictDto>();
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
			var schoolDistrictDto = _fixture.Create<CreateSchoolDistrictDto>();
			//Act
			var result = _validator.TestValidate(schoolDistrictDto);
			//Assert
			result.ShouldNotHaveAnyValidationErrors();
		}
	}
}
