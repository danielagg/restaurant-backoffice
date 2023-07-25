using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using restaurant_backoffice.UserManagement;

namespace restaurant_backoffice;

[Route("api/v1/users")]
public class UserManagementController : Controller
{
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignInAsync([FromBody] LoginRequest request)
    {
        // var user = await AuthenticateUser(request.Email, request.Password);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, request.Email),
            new Claim(ClaimTypes.Role, "Administrator"),
        };
        // [Authorize(Roles = "Administrator")]

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
            IsPersistent = true,
            IssuedUtc = DateTime.UtcNow
        };            

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(claimsIdentity), 
            authProperties);

        return Ok();
    }

    [HttpPost("sign-out")]
    public async Task<IActionResult> SignOutAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok();
    }
}
