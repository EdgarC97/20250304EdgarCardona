using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpGet("byStudentCode/{studentCode}")]
    public async Task<IActionResult> GetSubjectsByStudentCode(string studentCode)
    {
        var subjects = await _subjectService.GetSubjectsByStudentCodeAsync(studentCode);
        return Ok(subjects);
    }

    [HttpPost("add/{studentId}")]
    public async Task<IActionResult> AddSubject(int studentId, [FromBody] CreateSubjectRequest request)
    {
        var subject = await _subjectService.AddSubjectAsync(request, studentId);
        return Ok(subject);
    }
}