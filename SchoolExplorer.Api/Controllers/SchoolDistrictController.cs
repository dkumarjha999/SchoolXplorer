using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SchoolExplorer.Api.Constants;
using SchoolExplorer.Application.Common;
using SchoolExplorer.Application.Dtos;
using SchoolExplorer.Application.Services;

namespace SchoolExplorer.Api.Controllers
{
	[Route($"{ApiRoutes.Base}/[{ApiRoutes.Controller}]")]
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
				var createdSchoolDistrict = await _schoolDistrictService.CreateAsync(schoolDistrict);
				return Created($"{ApiRoutes.SchoolDistrictBaseUrl}/{createdSchoolDistrict.Id}", createdSchoolDistrict);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}