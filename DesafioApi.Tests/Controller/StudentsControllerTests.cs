using DesafioApi.DTOs;
using DesafioApi.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioApi.Tests.Controller
{
    public class StudentsControllerTests
    {
        [Fact]
        public async Task Get_ShouldReturnOk()
        {
            // Arrange

            var mockService = new Mock<IStudentService>();

            mockService.Setup(x => x.GetAll(It.IsAny<string>(), 0, 10).Item1)
                .Returns(new List<StudentDTO>
                {
                    new StudentDTO { Nome = "João" }
                });

            var controller =
                new StudentsController(
                    mockService.Object
                );

            // Act

            var result = controller.Get(1);

            // Assert

            result.Should()
                .BeOfType<OkObjectResult>();
        }
    }
}
