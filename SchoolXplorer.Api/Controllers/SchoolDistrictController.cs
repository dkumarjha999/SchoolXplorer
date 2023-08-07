using Microsoft.AspNetCore.Mvc;
using SchoolXplorer.Api.Constants;
using SchoolXplorer.Application.Common;
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
			try
			{
				if (schoolDistrict == null || !string.IsNullOrEmpty(schoolDistrict.Id))
				{
					return BadRequest(ResponseMessages.InvalidData);
				}
				return Created($"{ApiRoutes.SchoolDistrictBaseUrl}/{schoolDistrict.Id}", schoolDistrict);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
