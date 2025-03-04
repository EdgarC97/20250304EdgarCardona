using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Controllers;
using StudentManagementApi.Models.DTOs;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Tests.Setup;
using Xunit;

namespace StudentManagementApi.Tests.Controllers
{
    /// <summary>
    /// Unit tests for the StudentController.
    /// </summary>
    public class StudentControllerTests : TestBase
    {
        /// <summary>
        /// Tests that a valid request returns an OK result with the student data.
        /// </summary>
        [Fact]
        public async Task RegisterStudent_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            string id = "123456";
            var request = new CreateStudentRequest
            {
                Code = "STU001",
                Names = "John",
                Lastnames = "Doe",
                BirthDate = new DateTime(2000, 1, 1),
                Age = 25,
                Email = "john.doe@example.com",
                LogDetails = "Created"
            };

            // Create a fake student DTO to be returned by the service.
            var studentDto = new StudentDto
            {
                Id = id,
                Code = request.Code,
                Names = request.Names,
                Lastnames = request.Lastnames,
                BirthDate = request.BirthDate,
                Age = request.Age,
                Email = request.Email,
                LogDetails = request.LogDetails
            };

            // Setup the service mock to return the fake student DTO.
            // Using Returns(Task.FromResult(...)) si ReturnsAsync no está disponible.
            _studentServiceMock
                .Setup(s => s.RegisterStudentAsync(id, request))
                .Returns(Task.FromResult(studentDto));

            var controller = new StudentController(_studentServiceMock.Object);

            // Act
            var result = await controller.RegisterStudent(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = okResult.Value;

            // Use reflection to access properties of the anonymous type.
            var successProp = response.GetType().GetProperty("success");
            var messageProp = response.GetType().GetProperty("message");
            var dataProp = response.GetType().GetProperty("data");

            Assert.NotNull(successProp);
            Assert.NotNull(messageProp);
            Assert.NotNull(dataProp);

            bool success = (bool)successProp.GetValue(response)!;
            string message = (string)messageProp.GetValue(response)!;
            var data = dataProp.GetValue(response);

            Assert.True(success);
            Assert.Equal("Student registered/updated successfully.", message);
            Assert.NotNull(data);

            // Check that data has expected properties
            var idProp = data!.GetType().GetProperty("Id");
            var codeProp = data.GetType().GetProperty("Code");
            Assert.NotNull(idProp);
            Assert.NotNull(codeProp);

            string dataId = (string)idProp.GetValue(data)!;
            string dataCode = (string)codeProp.GetValue(data)!;

            Assert.Equal(id, dataId);
            Assert.Equal(request.Code, dataCode);
        }

        /// <summary>
        /// Tests that an invalid request (missing student code) returns a BadRequest.
        /// </summary>
        [Fact]
        public async Task RegisterStudent_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            string id = "123456";
            // Create a request with an empty Code.
            var request = new CreateStudentRequest
            {
                Code = "",
                Names = "John",
                Lastnames = "Doe",
                BirthDate = new DateTime(2000, 1, 1),
                Age = 25,
                Email = "john.doe@example.com",
                LogDetails = "Created"
            };

            var controller = new StudentController(_studentServiceMock.Object);

            // Act
            var result = await controller.RegisterStudent(id, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var response = badRequestResult.Value;

            // Use reflection to access properties
            var successProp = response.GetType().GetProperty("success");
            var messageProp = response.GetType().GetProperty("message");

            Assert.NotNull(successProp);
            Assert.NotNull(messageProp);

            bool success = (bool)successProp.GetValue(response)!;
            string message = (string)messageProp.GetValue(response)!;

            Assert.False(success);
            Assert.Equal("Student data is required and must include a code.", message);
        }
    }
}
