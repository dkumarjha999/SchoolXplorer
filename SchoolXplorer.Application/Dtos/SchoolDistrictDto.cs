namespace SchoolXplorer.Application.Dtos
{
	public class SchoolDistrictDto
	{
		public string Id { get; init; }
		public string Name { get; init; }
		public string Description { get; init; }
		public string City { get; set; }
		public string Superintendent { get; init; }
		public bool IsPublic { get; init; }
		public int NumberOfSchools { get; init; }
	}
}
