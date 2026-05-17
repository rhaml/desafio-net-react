using DesafioApi.DTOs;
using DesafioApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public IActionResult GetAll(
    string? nome,
    int? serie,
    int page = 1,
    int pageSize = 5)
    {
        var response = _service.GetAll(nome, page, pageSize);
        var data = response.Item1;
        var total = response.Item2;
        return Ok(new { data, total });
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var student = _service.GetById(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Create(StudentDTO dto)
        => Ok(_service.Create(dto));

    [HttpPut("{id}")]
    public IActionResult Update(int id, StudentDTO dto)
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