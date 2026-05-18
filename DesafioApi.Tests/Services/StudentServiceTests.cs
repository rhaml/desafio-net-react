using DesafioApi.Context;
using DesafioApi.DTOs;
using DesafioApi.Models;
using DesafioApi.Repository;
using DesafioApi.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioApi.Tests.Services
{
    public class StudentServiceTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetAll_ShouldReturnStudents()
        {
            // Arrange
            var context = GetDbContext();

            context.Students.Add(new Student
            {
                Nome = "João",
                Idade = 15,
                Serie = 1,
                NotaMedia = 8.5
            });

            await context.SaveChangesAsync();

            var repo = new StudentRepository(context);

            var result = repo.GetAll(null, 0, 10).Item1;

            result.Should().HaveCount(1);
            result.First().Nome.Should().Be("João");
        }

        [Fact]
        public async Task Create_ShouldAddStudent()
        {
            // Arrange

            var context = GetDbContext();

            var repo = new StudentRepository(context);

            var student = new Student
            {
                Nome = "Maria",
                Idade = 16,
                Serie = 2,
                NotaMedia = 9.2,
                DataNascimento = new DateTime(2008, 5, 20),
                Endereco = "Rua A, 123",
                NomeMae = "Ana",
                NomePai = "Carlos"
            };

            // Act

            repo.Add(student);

            // Assert

            context.Students.Count()
                .Should().Be(1);
        }
    }
}
