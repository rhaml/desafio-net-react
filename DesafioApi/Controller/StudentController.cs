using DesafioApi.DTOs;
using DesafioApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentsController(IStudentService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var student = _service.GetAll();
        return Ok(student);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var student = _service.GetById(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Create(StudentInsertDTO dto)
        => Ok(_service.Create(dto));

    [HttpPut("{id}")]
    public IActionResult Update(int id, StudentInsertDTO dto)
    {
        if (!_service.Update(id, dto))
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_service.Delete(id))
            return NotFound();

        return NoContent();
    }
}