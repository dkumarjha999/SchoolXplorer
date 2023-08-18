using SchoolExplorer.Api.Controllers;
using SchoolExplorer.Application.Common;

namespace SchoolExplorer.UnitTest.Api.Controllers
{
	public class SchoolDistrictControllerTests
	{
		private readonly Mock<ISchoolDistrictService> _mockSchoolDistrictService;
		private readonly IValidator<CreateSchoolDistrictDto> _validator;
		private readonly SchoolDistrictController _controller;
		private readonly Fixture _fixture;
		private readonly IMapper _mapper;
		public SchoolDistrictControllerTests()
		{
			_validator = new CreateSchoolDistrictDtoValidator();
			_mockSchoolDistrictService = new Mock<ISchoolDistrictService>();
			_mapper = new MapperConfiguration(cfg => cfg.AddProfile<SchoolDistrictProfile>()).CreateMapper();
			_controller = new SchoolDistrictController(_mockSchoolDistrictService.Object, _validator);
			_fixture = new Fixture();
		}
		[Fact]
		public async Task CreateSchoolDistrictAsync_WithValidData_ShouldReturnOkWithCreatedData()
		{
			// Arrange
			var createdSchoolDistrictDto = _fixture.Create<SchoolDistrictDto>();
			var newSchoolDistrictDto = _mapper.Map<CreateSchoolDistrictDto>(createdSchoolDistrictDto);

			_mockSchoolDistrictService.Setup(x => x.CreateAsync(It.IsAny<CreateSchoolDistrictDto>())).ReturnsAsync(createdSchoolDistrictDto);

			// Act
			var result = await _controller.CreateSchoolDistrictAsync(newSchoolDistrictDto);

			// Assert
			_mockSchoolDistrictService.Verify(x => x.CreateAsync(It.IsAny<CreateSchoolDistrictDto>()), Times.Once);
			result.Should().BeOfType<CreatedResult>().Which.Value.Should().BeEquivalentTo(newSchoolDistrictDto);
		}

		[Fact]
		public async Task CreateSchoolDistrictAsync_WithInvalidData_ShouldReturnBadRequestWithErrors()
		{
			// Arrange
			var invalidSchoolDistrictDto = new CreateSchoolDistrictDto();
			var validationErros = _validator.Validate(invalidSchoolDistrictDto).Errors.Select(error => error.ErrorMessage);
			// Act
			var result = await _controller.CreateSchoolDistrictAsync(invalidSchoolDistrictDto);

			// Assert
			result.Should().BeOfType<BadRequestObjectResult>().Which.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
			result.As<BadRequestObjectResult>().Value.Should().BeEquivalentTo(validationErros);
		}

		[Fact]
		public async Task CreateSchoolDistrictAsync_OnException_ShouldReturnsInternalServerError()
		{
			// Arrange
			var schoolDistrictDto = _fixture.Create<CreateSchoolDistrictDto>();

			_mockSchoolDistrictService.Setup(x => x.CreateAsync(It.IsAny<CreateSchoolDistrictDto>())).ThrowsAsync(new Exception(ResponseMessages.InternalServerError));

			// Act
			var result = await _controller.CreateSchoolDistrictAsync(schoolDistrictDto);

			// Assert
			result.Should().BeOfType<ObjectResult>().Which.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
			result.As<ObjectResult>().Value.Should().BeEquivalentTo(ResponseMessages.InternalServerError);
		}
	}
}
