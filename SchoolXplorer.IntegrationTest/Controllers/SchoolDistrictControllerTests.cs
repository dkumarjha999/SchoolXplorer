using SchoolXplorer.Api.Constants;
using SchoolXplorer.Application.Common;
using SchoolXplorer.Application.Dtos;

namespace SchoolXplorer.IntegrationTest.Controllers
{
	public class SchoolDistrictControllerTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly HttpClient _httpClient;
		private readonly Fixture _fixture;
		public SchoolDistrictControllerTests(WebApplicationFactory<Program> factory)
		{
			_httpClient = factory.CreateClient();
			_fixture = new Fixture();
		}

		[Fact]
		public async Task CreateSchoolDistrictAsync_WhithValidData_ShouldReturnCreatedSchoolDistrict()
		{
			//Arrange
			var schoolDistrictDto = _fixture.Create<CreateSchoolDistrictDto>();
			// Act
			var response = await _httpClient.PostAsJsonAsync(ApiRoutes.SchoolDistrictBaseUrl, schoolDistrictDto);
			var createdSchoolDistrict = await response.Content.ReadFromJsonAsync<SchoolDistrictDto>();
			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.Created);
			schoolDistrictDto.Should().BeEquivalentTo(createdSchoolDistrict, options => options.Excluding(X => X.Id));
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
