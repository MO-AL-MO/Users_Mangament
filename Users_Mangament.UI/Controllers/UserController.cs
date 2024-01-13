using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Users_Mangament.Application.Interfaces.IService;
using Users_Mangament.Domain.Models;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAllUsersAsync();
        return View(users);
    }

    public async Task<IActionResult> Details(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost, ActionName("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAsync(User user)
    {
        if (ModelState.IsValid)
        {
            await _userService.CreateUserAsync(user);
            return RedirectToAction(nameof(Index));
        }

        return View(user);
    }
    [HttpGet, ActionName("Edit")]
    public async Task<IActionResult> EditAsync(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }
    [HttpPost, ActionName("Edit")]  
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAsync(int id, User user)
    {
        if (id != user.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _userService.UpdateUserAsync(user);
            }
            catch (ApplicationException ex)
            {
               
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(user);
    }
    [HttpGet, ActionName("Delete")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmedAsync(int id)
    {
        await _userService.DeleteUserAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
