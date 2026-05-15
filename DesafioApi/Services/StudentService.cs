using AutoMapper;
using DesafioApi.Context;
using DesafioApi.DTOs;
using DesafioApi.Models;
using DesafioApi.Repository;
using DesafioApi.Repository.Interfaces;
using DesafioApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public StudentDTO Create(StudentInsertDTO dto)
        {
            var student = _mapper.Map<Student>(dto);
            _repo.Add(student);
          
            return GetById(student.Id);
        }

        public bool Delete(int id)
        {
            var student = _repo.GetById(id);
            if (student == null) return false;

            _repo.Delete(student);
            return true;
        }

        public List<StudentDTO> GetAll()
        {
            return _mapper.Map<List<StudentDTO>>(_repo.GetAll());
        }

        public StudentDTO GetById(int id)
        {
            var s = _repo.GetById(id);
            if (s == null) return null;
            return _mapper.Map<StudentDTO>(s);
        }

        public bool Update(int id, StudentInsertDTO dto)
        {
            var student = _repo.GetById(id);
            if (student == null) return false;
            student.Nome = dto.Nome;
            student.Idade = dto.Idade;
            student.Serie = dto.Serie;
            student.NotaMedia = dto.NotaMedia;
            student.Endereco = dto.Endereco;
            student.NomePai = dto.NomePai;
            student.NomeMae = dto.NomeMae;
            student.DataNascimento = dto.DataNascimento;

            _repo.Update(student);
            return true;
        }
    }
}
