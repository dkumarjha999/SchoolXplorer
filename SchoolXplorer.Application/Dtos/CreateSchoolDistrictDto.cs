﻿namespace SchoolXplorer.Application.Dtos
{
	public class CreateSchoolDistrictDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string City { get; set; }
		public string Superintendent { get; set; }
		public bool IsPublic { get; set; }
		public int NumberOfSchools { get; set; }
	}
}
