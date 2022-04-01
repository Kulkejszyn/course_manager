using DataAccess.Data.Enitites;

namespace Models;

public class TopicModel
{
	public int? TopicId { get; set; }
	public string Topic { get; set; }
	public int TopicNumber { get; set; }

	public static TopicModel FromEntity(CourseTopic topic)
	{
		return new TopicModel()
		{
			Topic = topic.Topic,
			TopicId = topic.TopicId,
			TopicNumber = topic.TopicNumber
		};
	}

	public CourseTopic ToEntity(int? courseId = null)
	{
		return new CourseTopic()
		{
			Topic = Topic,
			CourseId = courseId.GetValueOrDefault(),
			TopicId = TopicId.GetValueOrDefault(),
			TopicNumber = TopicNumber
		};
	}
}
