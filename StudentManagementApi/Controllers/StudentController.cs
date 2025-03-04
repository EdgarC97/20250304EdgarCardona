using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace StudentManagementApi.Controllers
{
    /// <summary>
    /// Controller to manage student operations, such as registration, retrieval, and updates.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        /// <summary>
        /// Initializes a new instance of the StudentController.
        /// </summary>
        /// <param name="studentService">The service to handle student operations.</param>
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Registers or updates a student with the specified identification number (e.g., ID card or cedula).
        /// </summary>
        /// <param name="id">The unique identification number of the student (e.g., cedula) provided in the URL.</param>
        /// <param name="request">The student data (excluding ID) to register or update.</param>
        /// <returns>A successful response with the created/updated student details, or an error if invalid.</returns>
        /// <response code="200">Returns the student details on success.</response>
        /// <response code="400">If the request data is invalid or missing required fields.</response>
        [HttpPost("{id}")]
        [SwaggerOperation(Summary = "Register or update a student by ID (cedula)", Description = "Creates a new student or updates an existing one with the provided data using their identification number (cedula) in the URL, without duplicating ID in the request body.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterStudent(string id, [FromBody] CreateStudentRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Code))
                return BadRequest("Student data is required and must include a code.");

            try
            {
                var student = await _studentService.RegisterStudentAsync(id, request);
                return Ok(new { success = true, message = "Student registered/updated successfully.", data = student });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"Error registering/updating student: {ex.Message}" });
            }
        }

        /// <summary>
        /// Retrieves a student by their unique identification number (e.g., ID card or cedula).
        /// </summary>
        /// <param name="id">The unique identification number of the student (e.g., cedula).</param>
        /// <returns>A successful response with the student details, or an error if not found.</returns>
        /// <response code="200">Returns the student details on success.</response>
        /// <response code="404">If the student is not found.</response>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a student by ID (cedula)", Description = "Fetches the details of a specific student by their identification number (cedula).")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentById(string id)
        {
            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                return Ok(new { success = true, message = "Student retrieved successfully.", data = student });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { success = false, message = "Student not found." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"Error retrieving student: {ex.Message}" });
            }
        }

        /// <summary>
        /// Retrieves all students in the system.
        /// </summary>
        /// <returns>A successful response with a list of all students, or an empty list if none exist.</returns>
        /// <response code="200">Returns the list of students on success.</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Get all students", Description = "Fetches a list of all registered students.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                return Ok(new { success = true, message = "Students retrieved successfully.", data = students });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"Error retrieving students: {ex.Message}" });
            }
        }

        /// <summary>
        /// Updates an existing student with the specified identification number (e.g., ID card or cedula).
        /// </summary>
        /// <param name="id">The unique identification number of the student (e.g., cedula) to update.</param>
        /// <param name="request">The student data (excluding ID) to update.</param>
        /// <returns>A successful response with the updated student details, or an error if not found or invalid.</returns>
        /// <response code="200">Returns the updated student details on success.</response>
        /// <response code="400">If the request data is invalid or the student is not found.</response>
        /// <response code="404">If the student is not found.</response>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a student by ID (cedula)", Description = "Updates an existing student with the provided data using their identification number (cedula) in the URL, without duplicating ID in the request body.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStudent(string id, [FromBody] CreateStudentRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Code))
                return BadRequest("Student data is required and must include a code.");

            try
            {
                var student = await _studentService.RegisterStudentAsync(id, request); 
                return Ok(new { success = true, message = "Student updated successfully.", data = student });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { success = false, message = "Student not found." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"Error updating student: {ex.Message}" });
            }
        }
    }
}