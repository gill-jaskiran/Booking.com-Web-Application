namespace WebApplication4.Models
{
	public class Listing
	{
		public int ListingId { get; set; }

		public required string Type { get; set; }

		public required string Name { get; set; }

		public string? Description { get; set; }

		public required decimal Price { get; set; }
	}
}
