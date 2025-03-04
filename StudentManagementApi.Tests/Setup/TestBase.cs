using Moq;
using StudentManagementApi.Services.Interfaces;

namespace StudentManagementApi.Tests.Setup
{
    /// <summary>
    /// Base class for unit tests providing a mock for IStudentService.
    /// </summary>
    public class TestBase
    {
        protected readonly Mock<IStudentService> _studentServiceMock;

        public TestBase()
        {
            // Initialize the IStudentService mock.
            _studentServiceMock = new Mock<IStudentService>();
        }
    }
}
