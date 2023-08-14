using SchoolExplorer.Api.Constants;
using SchoolExplorer.Application.Common;
using SchoolExplorer.Application.Dtos;
using SchoolExplorer.Application.Mappings;
using SchoolExplorer.IntegrationTest.Helpers;

namespace SchoolExplorer.IntegrationTest.Controllers
{
	public class SchoolDistrictControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
	{
		private readonly IMapper _mapper;
		private readonly Fixture _fixture;
		private readonly HttpClient _httpClient;
		private readonly CustomWebApplicationFactory<Program> _factory;
		public SchoolDistrictControllerTests(CustomWebApplicationFactory<Program> factory)
		{
			_factory = factory;
			_httpClient = _factory.CreateClient();
			_fixture = new Fixture();
			_mapper = new MapperConfiguration(cfg => cfg.AddProfile<SchoolDistrictProfile>()).CreateMapper();
		}

		[Fact]
		public async Task CreateSchoolDistrictAsync_WhithValidData_ShouldReturnCreatedSchoolDistrict()
		{
			//Arrange
			Utilities.ReinitializeDb(_factory);
			var schoolDistrict = Utilities.GenerateSeedingSchoolDistricts(1)[0];
			var createSchoolDistrictDto = _mapper.Map<CreateSchoolDistrictDto>(schoolDistrict);

			// Act
			var response = await _httpClient.PostAsJsonAsync(ApiRoutes.SchoolDistrictBaseUrl, createSchoolDistrictDto);
			var createdSchoolDistrict = await response.Content.ReadFromJsonAsync<SchoolDistrictDto>();
			var createdSchoolDistrictDto = _mapper.Map<CreateSchoolDistrictDto>(createdSchoolDistrict);

			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.Created);
			createSchoolDistrictDto.Should().BeEquivalentTo(createdSchoolDistrictDto);
		}
		[Fact]
		public async Task CreateSchoolDistrictAsync_WhithInValidData_ShouldReturnBadRequest()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<CreateSchoolDistrictDto>();
			schoolDistrictDto.Name=String.Empty;

			// Act
			var response = await _httpClient.PostAsJsonAsync(ApiRoutes.SchoolDistrictBaseUrl, schoolDistrictDto);
			var content = await response.Content.ReadAsStringAsync();

			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
			content.Should().Contain(ResponseMessages.InvalidData);
		}
	}
}
