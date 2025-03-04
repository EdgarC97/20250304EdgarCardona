using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> RegisterStudent(int id, [FromBody] CreateStudentRequest request)
    {
        var student = await _studentService.RegisterStudentAsync(id, request);
        return Ok(student);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        return Ok(student);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students);
    }
}