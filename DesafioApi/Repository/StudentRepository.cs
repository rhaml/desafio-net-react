using DesafioApi.Context;
using DesafioApi.DTOs;
using DesafioApi.Models;
using DesafioApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DesafioApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Tuple<List<Student>, int> GetAll(string nome, int page, int pageSize)
        {
            var query = _context.Students.AsQueryable();
            if (!string.IsNullOrEmpty(nome))
                query = query.Where(s => s.Nome.Contains(nome));

            var total = query.Count();

            var data = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return new Tuple<List<Student>, int>(data, total);
        }

        public Student GetById(int id) => _context.Students.Find(id);

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
