using System.ComponentModel.DataAnnotations;
using DataAccess.Data.Enitites;

namespace DataAccess.Enitites;

public class Course
{
	[Key]
	public int CourseId { get; set; }

	[MaxLength(30)]
	public string Name { get; set; }

	[MaxLength(40)]
	public string Description { get; set; }
	public ICollection<CourseTopic> CourseTopics { get; set; }
}
