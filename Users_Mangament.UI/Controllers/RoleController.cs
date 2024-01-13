
using Microsoft.AspNetCore.Mvc;
using Users_Mangament.Application.DTOs.Request;
using Users_Mangament.Application.Interfaces.IService;

public class RoleController : Controller
{
    // حقول الخدمات
    private readonly IRoleService _roleService;
    private readonly IPermissionService _permissionService;

    // Constructor لحقل الخدمات
    public RoleController(IRoleService roleService, IPermissionService permissionService)
    {
        _roleService = roleService;
        _permissionService = permissionService;
    }

    // عرض قائمة الأدوار
    public async Task<IActionResult> Index()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return View(roles);
    }

    // عرض تفاصيل دور
    public async Task<IActionResult> Details(int id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);

        if (role == null)
        {
            return NotFound();
        }

        return View(role);
    }

    // عرض صفحة إنشاء دور جديد
    public async Task<IActionResult> Create()
    {
        var allPermissions = await _permissionService.GetAllPermissionsAsync();
        var viewModel = new RoleDTO { Permissions = allPermissions };
        return View(viewModel);
    }

    // إنشاء دور جديد
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RoleDTO roleDTO)
    {
        if (ModelState.IsValid)
        {
            await _roleService.CreateRoleAsync(roleDTO);
            return RedirectToAction(nameof(Index));
        }

        var allPermissions = await _permissionService.GetAllPermissionsAsync();
        roleDTO.Permissions = allPermissions;

        return View(roleDTO);
    }

    // عرض صفحة تحرير دور
    public async Task<IActionResult> Edit(int id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);

        if (role == null)
        {
            return NotFound();
        }

        var allPermissions = await _permissionService.GetAllPermissionsAsync();
        var viewModel = new RoleDTO
        {
            Id = role.Id,
            Name = role.Name,
            Permissions = allPermissions,
            SelectedPermissionIds = role.RolePermissions.Select(rp => rp.PermissionId).ToList()
        };

        return View(viewModel);
    }

    // تحديث دور
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(RoleDTO roleDTO)
    {
        if (ModelState.IsValid)
        {
            await _roleService.UpdateRoleAsync(roleDTO);
            return RedirectToAction(nameof(Index));
        }

        var allPermissions = await _permissionService.GetAllPermissionsAsync();
        roleDTO.Permissions = allPermissions;

        return View(roleDTO);
    }

    // عرض صفحة حذف دور
    public async Task<IActionResult> Delete(int id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);

        if (role == null)
        {
            return NotFound();
        }

        return View(role);
    }

    // حذف دور
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _roleService.DeleteRoleAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
