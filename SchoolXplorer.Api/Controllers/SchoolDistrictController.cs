using FluentValidation;
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
		private readonly IValidator<CreateSchoolDistrictDto> _validator;
		public SchoolDistrictController(IValidator<CreateSchoolDistrictDto> validator)
		{
			_validator=validator;
		}
		[HttpPost]
		public async Task<IActionResult> CreateSchoolDistrictAsync([FromBody] CreateSchoolDistrictDto schoolDistrict)
		{
			try
			{
				var validatorResult = _validator.Validate(schoolDistrict);
				if (!validatorResult.IsValid)
				{
					return BadRequest(ResponseMessages.InvalidData);
				}
				return Created($"{ApiRoutes.SchoolDistrictBaseUrl}/1", schoolDistrict);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
