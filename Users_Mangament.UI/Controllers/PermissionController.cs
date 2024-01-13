// Controllers/PermissionController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Users_Mangament.Application.DTOs.Request;
using Users_Mangament.Application.Interfaces.IService;
using Users_Mangament.Application.ServiceImp;
using Users_Mangament.Domain.Models;

public class PermissionController : Controller
{
    private readonly IPermissionService _permissionService;

    public PermissionController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    public async Task<IActionResult> Index()
    {
        var permissions = await _permissionService.GetAllPermissionsAsync();
        return View(permissions);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Permission permission)
    {
        if (ModelState.IsValid)
        {
            await _permissionService.CreatePermissionAsync(permission);
            return RedirectToAction(nameof(Index));
        }

        return View(permission);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var permission = await _permissionService.GetPermissionByIdAsync(id);

        if (permission == null)
        {
            return NotFound();
        }

        return View(permission);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Permission permission)
    {
        if (id != permission.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _permissionService.UpdatePermissionAsync( permission);
            }
            catch (ApplicationException ex)
            {

                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(permission);
    }
    [HttpGet, ActionName("Delete")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var user = await _permissionService.GetPermissionByIdAsync(id);

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
        await _permissionService.DeletePermissionAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
