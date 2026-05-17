using DesafioApi.Models;

namespace DesafioApi.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Tuple<List<Student>, int> GetAll(string nome, int page, int pageSize);
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}
