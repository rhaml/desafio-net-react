using DesafioApi.Models;

namespace DesafioApi.Repository.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}
