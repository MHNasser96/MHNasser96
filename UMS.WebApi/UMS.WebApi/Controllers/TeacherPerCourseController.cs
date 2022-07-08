using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.Entities.TeacherPerCourse.Commands.AddTeacherPerCourse;
using UMS.Application.Entities.TeacherPerCourse.Queries;
using UMS.Application.Entities.TeacherPerCourse.Queries.GetTeacherPerCourses;
using UMS.Domain.Models;

namespace UMS.WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]

public class TeacherPerCourseController : Controller
{
    private readonly IMediator _mediator;

    public TeacherPerCourseController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet()]
    public async Task<List<TeacherPerCourse>> GetTeacherPerCourses()
    {
        var result = await _mediator.Send(new GetTeacherPerCoursesQuery());
        return  result;
    }
    
    [HttpPost("Create")]
    public async Task<IActionResult> AddTeacherPerCourse(AddTeacherPerCourseCommand addTeacherPerCourseCommand)
    {
        var result =  await _mediator.Send(addTeacherPerCourseCommand);
        if (result == null)
        {
            return BadRequest("The user must be a teacher to be assigned to a course!!!");
        }
        return Ok(result);
    }
    
}