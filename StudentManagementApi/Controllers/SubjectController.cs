using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace StudentManagementApi.Controllers
{
    /// <summary>
    /// Controller to manage subject operations such as retrieving subjects by student code and adding new subjects.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectController"/> class.
        /// </summary>
        /// <param name="subjectService">Service to handle subject operations.</param>
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// Retrieves all subjects associated with a student by their code.
        /// </summary>
        /// <param name="studentCode">Unique code of the student.</param>
        /// <returns>
        /// Returns OK with a list of subjects if found; otherwise, NotFound if no subjects exist or the student is not found.
        /// </returns>
        [HttpGet("byStudentCode/{studentCode}")]
        [SwaggerOperation(
            Summary = "Get subjects by student code",
            Description = "Fetches all subjects for a student identified by their code."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSubjectsByStudentCode(string studentCode)
        {
            try
            {
                // Retrieve subjects from the service
                var subjects = await _subjectService.GetSubjectsByStudentCodeAsync(studentCode);

                // Check if the returned list is null or empty
                if (subjects == null || !subjects.Any())
                {
                    throw new KeyNotFoundException("No subjects found for the provided student code.");
                }

                return Ok(new { success = true, message = "Subjects retrieved successfully.", data = subjects });
            }
            catch (KeyNotFoundException)
            {
                // Return NotFound if no subjects are available for the student code
                return NotFound(new { success = false, message = "Student not found or no subjects available." });
            }
            catch (Exception ex)
            {
                // Return a bad request with error details
                return BadRequest(new { success = false, message = $"Error retrieving subjects: {ex.Message}" });
            }
        }

        /// <summary>
        /// Adds a new subject for a specific student.
        /// </summary>
        /// <param name="studentId">Unique identification number of the student.</param>
        /// <param name="request">Subject data to add.</param>
        /// <returns>Returns OK with the new subject details or a bad request error.</returns>
        [HttpPost("add/{studentId}")]
        [SwaggerOperation(
            Summary = "Add a new subject for a student",
            Description = "Creates a new subject associated with the specified student's identification number."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddSubject(string studentId, [FromBody] CreateSubjectRequest request)
        {
            // Validate request input
            if (request == null || string.IsNullOrEmpty(request.Code))
                return BadRequest(new { success = false, message = "Subject data is required and must include a code." });

            try
            {
                // Call the service to add the subject
                var subject = await _subjectService.AddSubjectAsync(request, studentId);
                return Ok(new { success = true, message = "Subject added successfully.", data = subject });
            }
            catch (KeyNotFoundException)
            {
                // Return BadRequest if the student is not found (as per current business logic)
                return BadRequest(new { success = false, message = "Student not found." });
            }
            catch (Exception ex)
            {
                // Return a bad request with error details
                return BadRequest(new { success = false, message = $"Error adding subject: {ex.Message}" });
            }
        }
    }
}
