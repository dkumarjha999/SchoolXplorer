using SchoolXplorer.Application.Dtos;
using SchoolXplorer.Application.Services;
using SchoolXplorer.Domain.Entities;
using SchoolXplorer.Domain.Repositories;

namespace SchoolXplorer.UnitTest.Application.Services
{
	public class SchoolDistrictServiceTests
	{
		private readonly SchoolDistrictService _schoolDistrictService;
		private readonly Mock<ISchoolDistrictRepository> _mockSchoolDistrictRepository;
		private readonly Fixture _fixture;
		public SchoolDistrictServiceTests()
		{
			_mockSchoolDistrictRepository = new Mock<ISchoolDistrictRepository>();
			_schoolDistrictService = new SchoolDistrictService(_mockSchoolDistrictRepository.Object);
			_fixture = new Fixture();
		}

		[Fact]
		public async Task CreateSchoolDistrictAsync_WithValidData_ShouldReturnSchoolDistrictDto()
		{
			//Arrange
			var newSchoolDistrictDto = _fixture.Create<CreateSchoolDistrictDto>();

			var createdSchoolDistrict = _fixture.Create<SchoolDistrict>();
			_mockSchoolDistrictRepository.Setup(X => X.CreateSchoolDistrictAsync(createdSchoolDistrict)).ReturnsAsync(createdSchoolDistrict);

			// Act
			var result = _schoolDistrictService.CreateSchoolDistrictAsync(newSchoolDistrictDto);

			// Assert
			_mockSchoolDistrictRepository.Verify(X => X.CreateSchoolDistrictAsync(createdSchoolDistrict), Times.Once);
			result.Should().BeEquivalentTo(createdSchoolDistrict);
		}
	}
}
