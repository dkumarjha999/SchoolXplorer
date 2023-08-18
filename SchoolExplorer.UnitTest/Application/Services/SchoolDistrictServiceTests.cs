using SchoolExplorer.Domain.Entities;
using SchoolExplorer.Domain.Repositories;

namespace SchoolExplorer.UnitTest.Application.Services
{
	public class SchoolDistrictServiceTests
	{
		private readonly SchoolDistrictService _schoolDistrictService;
		private readonly Mock<ISchoolDistrictRepository> _mockSchoolDistrictRepository;
		private readonly Fixture _fixture;
		private readonly IMapper _mapper;
		public SchoolDistrictServiceTests()
		{
			_mapper = new MapperConfiguration(cfg => cfg.AddProfile<SchoolDistrictProfile>()).CreateMapper();
			_mockSchoolDistrictRepository = new Mock<ISchoolDistrictRepository>();
			_schoolDistrictService = new SchoolDistrictService(_mockSchoolDistrictRepository.Object, _mapper);
			_fixture = new Fixture();
		}

		[Fact]
		public async Task CreateAsync_WithValidData_ShouldReturnSchoolDistrictDto()
		{
			//Arrange
			var createdSchoolDistrict = _fixture.Create<SchoolDistrict>();
			_mockSchoolDistrictRepository.Setup(X => X.CreateAsync(It.IsAny<SchoolDistrict>())).ReturnsAsync(createdSchoolDistrict);

			// Act
			var result = await _schoolDistrictService.CreateAsync(_mapper.Map<CreateSchoolDistrictDto>(createdSchoolDistrict));

			// Assert
			_mockSchoolDistrictRepository.Verify(X => X.CreateAsync(It.IsAny<SchoolDistrict>()), Times.Once);
			result.Should().BeEquivalentTo(_mapper.Map<SchoolDistrictDto>(createdSchoolDistrict));
		}
	}
}
