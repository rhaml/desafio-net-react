using DesafioApi.DTOs;

namespace DesafioApi.Services.Interfaces
{
    public interface IStudentService
    {
        Tuple<List<StudentDTO>, int> GetAll(string nome, int page, int pageSize);
        StudentDTO GetById(int id);
        StudentDTO Create(StudentDTO dto);
        bool Update(int id, StudentDTO dto);
        bool Delete(int id);
    }
}
