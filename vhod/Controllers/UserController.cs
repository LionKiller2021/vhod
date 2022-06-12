using Microsoft.AspNetCore.Mvc;
using vhod.Context;
using vhod.Models;

namespace vhod.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }
    [HttpPost("SignUp")]
    public Guid SignUp(UserRegistrationDTO newuser)
    {
        var user = new User()
        {
            FirstName = newuser.FirstName,
            LastName = newuser.LastName,
            Email = newuser.Email,
            Password = newuser.Password
        };
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.UserId;
    }
}

public class UserRegistrationDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}