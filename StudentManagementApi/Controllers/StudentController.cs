using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace StudentManagementApi.Controllers
{
    /// <summary>
    /// Controller to manage student operations such as registration, retrieval, and updates.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentController"/> class.
        /// </summary>
        /// <param name="studentService">Service to handle student operations.</param>
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Registers or updates a student using the specified identification number.
        /// </summary>
        /// <param name="id">Unique identification number of the student.</param>
        /// <param name="request">Student data excluding the ID.</param>
        /// <returns>Returns OK with student details or BadRequest if the input is invalid.</returns>
        [HttpPost("{id}")]
        [SwaggerOperation(
            Summary = "Register or update a student by ID",
            Description = "Creates a new student or updates an existing one using their identification number."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterStudent(string id, [FromBody] CreateStudentRequest request)
        {
            // Validate request input
            if (request == null || string.IsNullOrEmpty(request.Code))
                return BadRequest(new { success = false, message = "Student data is required and must include a code." });

            try
            {
                // Call the service to register or update the student
                var student = await _studentService.RegisterStudentAsync(id, request);
                return Ok(new { success = true, message = "Student registered/updated successfully.", data = student });
            }
            catch (Exception ex)
            {
                // Return a bad request with error details
                return BadRequest(new { success = false, message = $"Error registering/updating student: {ex.Message}" });
            }
        }

        /// <summary>
        /// Retrieves a student by their unique identification number.
        /// </summary>
        /// <param name="id">Unique identification number of the student.</param>
        /// <returns>Returns OK with student details if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a student by ID",
            Description = "Fetches details of a specific student by their identification number."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentById(string id)
        {
            try
            {
                // Retrieve the student from the service
                var student = await _studentService.GetStudentByIdAsync(id);
                return Ok(new { success = true, message = "Student retrieved successfully.", data = student });
            }
            catch (KeyNotFoundException)
            {
                // Return NotFound if the student does not exist
                return NotFound(new { success = false, message = "Student not found." });
            }
            catch (Exception ex)
            {
                // Return a bad request for any other error
                return BadRequest(new { success = false, message = $"Error retrieving student: {ex.Message}" });
            }
        }

        /// <summary>
        /// Updates an existing student with new data.
        /// </summary>
        /// <param name="id">Unique identification number of the student.</param>
        /// <param name="request">Student data excluding the ID.</param>
        /// <returns>Returns OK with updated student details or an error response.</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a student by ID",
            Description = "Updates an existing student with the provided data using their identification number."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStudent(string id, [FromBody] CreateStudentRequest request)
        {
            // Validate request input
            if (request == null || string.IsNullOrEmpty(request.Code))
                return BadRequest(new { success = false, message = "Student data is required and must include a code." });

            try
            {
                // Reuse the same service method for registration/updating
                var student = await _studentService.RegisterStudentAsync(id, request);
                return Ok(new { success = true, message = "Student updated successfully.", data = student });
            }
            catch (KeyNotFoundException)
            {
                // Return NotFound if the student does not exist
                return NotFound(new { success = false, message = "Student not found." });
            }
            catch (Exception ex)
            {
                // Return a bad request with error details
                return BadRequest(new { success = false, message = $"Error updating student: {ex.Message}" });
            }
        }
    }
}
