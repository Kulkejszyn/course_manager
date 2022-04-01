using App.Data;
using DataAccess.Data.Enitites;
using DataAccess.Enitites;
using Microsoft.EntityFrameworkCore;
using Models;

namespace App.Services;

public interface ICoursesService
{
	IEnumerable<CourseModel> GetCourses();
	void DeleteCourse(int id);
	void CreateOrUpdateCourse(CourseModel model);
	CourseModel? GetCourseById(int id);
}

public class CoursesService : ICoursesService
{
	private readonly DatabaseContext _databaseContext;

	public CoursesService(DatabaseContext databaseContext)
	{
		_databaseContext = databaseContext;
	}

	public CourseModel? GetCourseById(int id)
	{
		var course = _databaseContext.Courses
			.Include(course => course.CourseTopics)
			.FirstOrDefault(course => course.CourseId == id);
		return course is null ? CourseModel.FromEntity(course) : null;
	}

	public IEnumerable<CourseModel> GetCourses()
	{
		return _databaseContext.Courses
			.Include(course => course.CourseTopics)
			.ToList()
			.Select(CourseModel.FromEntity);
	}

	public void DeleteCourse(int id)
	{
		var course = _databaseContext.Courses.SingleOrDefault(course => course.CourseId == id);
		if (course is null) return;
		_databaseContext.Remove(course);
		_databaseContext.SaveChanges();
	}

	public void CreateOrUpdateCourse(CourseModel model)
	{
		if (model.CourseId.HasValue)
		{
			UpdateCourse(model);
		}
		else
		{
			CreateCourse(model);
		}
	}

	private void CreateCourse(CourseModel model)
	{
		_databaseContext.Courses.Add(new Course()
		{
			Description = model.Description,
			Name = model.Name,
			CourseTopics = model.Topics.Select(topic => topic.ToEntity(model.CourseId)).ToList()
		});
		_databaseContext.SaveChanges();
	}

	private void UpdateCourse(CourseModel model)
	{
		var course = _databaseContext.Courses
			.Include(course => course.CourseTopics)
			.SingleOrDefault(course => course.CourseId == model.CourseId);
		if(course is null) return;
		
		course.CourseTopics = model.Topics.Select(topic => new CourseTopic()
		{
			Topic = topic.Topic,
			CourseId = model.CourseId.GetValueOrDefault(),
			TopicId = topic.TopicId.GetValueOrDefault(),
			TopicNumber = topic.TopicNumber
		}).ToList();
		course.Description = model.Description;
		course.Name = model.Name;
		_databaseContext.Courses.Update(course);
		_databaseContext.SaveChanges();
	}
}
