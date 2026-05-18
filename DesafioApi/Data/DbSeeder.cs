using CsvHelper;
using CsvHelper.Configuration;
using DesafioApi.Context;
using DesafioApi.DTOs;
using DesafioApi.Models;
using System.Globalization;

namespace DesafioApi.Data
{

    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Username = "admin",
                    Password = "Admin123!"
                });
            }

            if (!context.Students.Any())
            {
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "Data",
                    "students.csv"
                );

                using var reader = new StreamReader(path);

                var config = new CsvConfiguration(
                    CultureInfo.InvariantCulture
                )
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };

                using var csv = new CsvReader(reader, config);

                var records = csv.GetRecords<StudentDTO>()
                                 .ToList();

                var students = records.Select(x => new Student
                {
                    Nome = x.Nome,
                    Idade = x.Idade,
                    Serie = x.Serie,
                    NotaMedia = x.NotaMedia,
                    Endereco = x.Endereco,
                    NomePai = x.NomePai,
                    NomeMae = x.NomeMae,
                    DataNascimento = x.DataNascimento
                });

                context.Students.AddRange(students);
            }

            context.SaveChanges();
        }
    }
}
