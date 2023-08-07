using Microsoft.AspNetCore.Mvc;
using SchoolXplorer.Api.Constants;
using SchoolXplorer.Application.Dtos;

namespace SchoolXplorer.Api.Controllers
{
	[Route($"{ApiRoutes.Base}/[controller]")]
	[ApiController]
	public class SchoolDistrictController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> CreateSchoolDistrictAsync([FromBody] SchoolDistrictDto schoolDistrict)
		{
			throw new NotImplementedException();
		}
	}
}
