using DesafioApi.DTOs;

namespace DesafioApi.Services.Interfaces
{
    public interface IStudentService
    {
        List<StudentDTO> GetAll();
        StudentDTO GetById(int id);
        StudentDTO Create(StudentInsertDTO dto);
        bool Update(int id, StudentInsertDTO dto);
        bool Delete(int id);
    }
}
