using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SchoolXplorer.Api.Constants;
using SchoolXplorer.Application.Common;
using SchoolXplorer.Application.Dtos;
using SchoolXplorer.Application.Services;

namespace SchoolXplorer.Api.Controllers
{
	[Route($"{ApiRoutes.Base}/[controller]")]
	[ApiController]
	public class SchoolDistrictController : ControllerBase
	{
		private readonly IValidator<CreateSchoolDistrictDto> _validator;
		private readonly ISchoolDistrictService _schoolDistrictService;
		public SchoolDistrictController(ISchoolDistrictService schoolDistrictService, IValidator<CreateSchoolDistrictDto> validator)
		{
			_validator=validator;
			_schoolDistrictService=schoolDistrictService;
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
				var createdSchoolDistrict = await _schoolDistrictService.CreateSchoolDistrictAsync(schoolDistrict);
				return Created($"{ApiRoutes.SchoolDistrictBaseUrl}/{createdSchoolDistrict.Id}", createdSchoolDistrict);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
