using DataAccess.Enitites;

namespace Models;

public class CourseModel
{
	public int? CourseId { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public List<TopicModel> Topics { get; set; }

	public static CourseModel FromEntity(Course course)
	{
		return new CourseModel()
		{
			CourseId = course.CourseId,
			Description = course.Description,
			Name = course.Name,
			Topics = course.CourseTopics.Select(TopicModel.FromEntity).ToList()
		};
	}
}
