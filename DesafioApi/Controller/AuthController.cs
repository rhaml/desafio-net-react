using DesafioApi.Context;
using DesafioApi.DTOs;
using DesafioApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;

    public AuthController(AppDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDTO dto)
    {
        var user = _context.Users
            .FirstOrDefault(u =>
                u.Username == dto.Username &&
                u.Password == dto.Password);

        if (user == null)
            return Unauthorized("Usuário inválido");

        var token = _tokenService.GenerateToken(user);

        return Ok(new { token });
    }

    [HttpPost("AddUser")]
    public IActionResult User(LoginDTO dto)
    {
        var user = new DesafioApi.Models.User { Username = dto.Username, Password = dto.Password };
        _context.Users
            .Add(user);
        _context.SaveChanges();

       
        return Ok(user);
    }
}