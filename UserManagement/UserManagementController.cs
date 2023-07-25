using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace restaurant_backoffice;

[Route("users")]
public class UserManagementController : Controller
{
    [HttpPost("login")]
    public async Task<IActionResult> Login()
    {
        await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "")
        })));

        return Ok();
    }
}
