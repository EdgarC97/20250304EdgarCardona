using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace StudentManagementApi.Controllers
{
    /// <summary>
    /// Controller to manage subject operations, such as retrieving subjects by student code and adding new subjects.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        /// <summary>
        /// Initializes a new instance of the SubjectController.
        /// </summary>
        /// <param name="subjectService">The service to handle subject operations.</param>
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// Retrieves all subjects associated with a student by their code.
        /// </summary>
        /// <param name="studentCode">The unique code of the student.</param>
        /// <returns>A successful response with the list of subjects, or an error if the student is not found.</returns>
        /// <response code="200">Returns the list of subjects on success.</response>
        /// <response code="404">If the student is not found or has no subjects.</response>
        [HttpGet("byStudentCode/{studentCode}")]
        [SwaggerOperation(Summary = "Get subjects by student code", Description = "Fetches all subjects for a student identified by their code.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSubjectsByStudentCode(string studentCode)
        {
            try
            {
                var subjects = await _subjectService.GetSubjectsByStudentCodeAsync(studentCode);
                return Ok(new { success = true, message = "Subjects retrieved successfully.", data = subjects });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { success = false, message = "Student not found or no subjects available." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"Error retrieving subjects: {ex.Message}" });
            }
        }

        /// <summary>
        /// Adds a new subject for a specific student.
        /// </summary>
        /// <param name="studentId">The unique identification number (e.g., ID card or cedula) of the student.</param>
        /// <param name="request">The subject data to add.</param>
        /// <returns>A successful response with the created subject details, or an error if invalid.</returns>
        /// <response code="200">Returns the new subject details on success.</response>
        /// <response code="400">If the request data is invalid or the student is not found.</response>
        [HttpPost("add/{studentId}")]
        [SwaggerOperation(Summary = "Add a new subject for a student", Description = "Creates a new subject associated with the specified student identification number (cedula).")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddSubject(string studentId, [FromBody] CreateSubjectRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Code))
                return BadRequest("Subject data is required and must include a code.");

            try
            {
                var subject = await _subjectService.AddSubjectAsync(request, studentId);
                return Ok(new { success = true, message = "Subject added successfully.", data = subject });
            }
            catch (KeyNotFoundException)
            {
                return BadRequest(new { success = false, message = "Student not found." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"Error adding subject: {ex.Message}" });
            }
        }
    }
}