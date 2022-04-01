using App.Services;
using DataAccess;
using DataAccess.Data.Enitites;
using DataAccess.Enitites;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
	private ICoursesService _coursesService;

	public CoursesController(ICoursesService coursesService)
	{
		_coursesService = coursesService;
	}

	[HttpPost("CreateOrUpdate")]
	public void CreateOrUpdateCourse(CourseModel model)
	{
		_coursesService.CreateOrUpdateCourse(model);
	}

	[HttpGet]
	public IEnumerable<CourseModel> GetCourses()
	{
		return _coursesService.GetCourses();
	}
	
	[HttpGet("{id}")]
	public CourseModel? GetCourseById(int id)
	{
		return _coursesService.GetCourseById(id);
	}

	[HttpDelete("{id}")]
	public void DeleteCourse(int id)
	{
		_coursesService.DeleteCourse(id);
	}
}
