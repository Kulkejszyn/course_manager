using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Enitites;

namespace DataAccess.Data.Enitites;

public class CourseTopic
{
	[Key]
	public int TopicId { get; set; }

	[ForeignKey(nameof(Course.CourseId))]
	public int CourseId { get; set; }

	[MaxLength(40)]
	public string Topic { get; set; }

	public int TopicNumber { get; set; }
}
