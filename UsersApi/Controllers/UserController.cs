using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Entities;
using UsersApi.Data.Interfaces;

namespace UsersApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]  
    public IActionResult GetAllUsers()
    {
        var users = _userRepository.GetUsersOrderedByName();
        return Ok(users);
    }

    [HttpGet("{id}",Name = nameof(GetUser))]
    public IActionResult GetUser(int id)
    {
        var user = _userRepository.GetById(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet]
    [Route("search")]
    public IActionResult SearchUsersByName([FromQuery] string name)
    {
        var users = _userRepository.FindUsersByName(name);
        if (!users.Any())
        {
            return NotFound($"Nenhum usuário encontrado com o nome ({name}) na pesquisa.");
        }
        return Ok(users);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        _userRepository.Add(user);
        _unitOfWork.Commit();

        return CreatedAtRoute(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        var existingUser = _userRepository.GetById(id);
        if (existingUser == null)
            return NotFound();

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        // Atualize outros campos, se necessário

        _userRepository.Update(existingUser);
        _unitOfWork.Commit();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _userRepository.GetById(id);
        if (user == null)
            return NotFound();

        _userRepository.Remove(user);
        _unitOfWork.Commit();

        return NoContent();
    }
}
