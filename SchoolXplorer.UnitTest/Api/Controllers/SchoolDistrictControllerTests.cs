using SchoolXplorer.Api.Controllers;
using SchoolXplorer.Application.Common;
using SchoolXplorer.Application.Dtos;
using SchoolXplorer.Application.Services;
using SchoolXplorer.Application.Validators;

namespace SchoolXplorer.UnitTest.Api.Controllers
{
	public class SchoolDistrictControllerTests
	{
		private readonly Mock<ISchoolDistrictService> _mockSchoolDistrictService;
		private readonly IValidator<CreateSchoolDistrictDto> _validator;
		private readonly SchoolDistrictController _controller;
		private readonly Fixture _fixture;

		public SchoolDistrictControllerTests()
		{
			_validator = new CreateSchoolDistrictDtoValidator();
			_mockSchoolDistrictService = new Mock<ISchoolDistrictService>();
			_controller = new SchoolDistrictController(_mockSchoolDistrictService.Object, _validator);
			_fixture = new Fixture();
		}
		[Fact]
		public async Task CreateSchoolDistrictAsync_WithValidData_ShouldReturnOkWithCreatedData()
		{
			// Arrange
			var newSchoolDistrictDto = _fixture.Create<CreateSchoolDistrictDto>();
			var createdSchoolDistrictDto = _fixture.Create<SchoolDistrictDto>();

			_mockSchoolDistrictService.Setup(x => x.CreateSchoolDistrictAsync(newSchoolDistrictDto)).ReturnsAsync(createdSchoolDistrictDto);

			// Act
			var result = await _controller.CreateSchoolDistrictAsync(newSchoolDistrictDto);

			// Assert
			_mockSchoolDistrictService.Verify(x => x.CreateSchoolDistrictAsync(newSchoolDistrictDto), Times.Once);
			result.Should().BeOfType<CreatedResult>().Which.Value.Should().BeEquivalentTo(newSchoolDistrictDto);
		}

		[Fact]
		public async Task CreateSchoolDistrictAsync_WithInvalidData_ShouldReturnBadRequestWithErrors()
		{
			// Arrange
			var invalidSchoolDistrictDto = new CreateSchoolDistrictDto();
			// Act
			var result = await _controller.CreateSchoolDistrictAsync(invalidSchoolDistrictDto);

			// Assert
			result.Should().BeOfType<BadRequestObjectResult>().Which.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
			result.As<BadRequestObjectResult>().Value.Should().BeEquivalentTo(ResponseMessages.InvalidData);
		}
	}
}
