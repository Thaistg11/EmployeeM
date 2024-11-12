using EmployeeM.Data;
using EmployeeM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeM.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ThemeRepository _themeRepository;

        public ThemeController(IHttpContextAccessor httpContextAccessor, ThemeRepository themeRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _themeRepository = themeRepository;
        }

        // Method to get the current user's ID
        private string GetCurrentUserId()
        {
            var CurrentUserId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return CurrentUserId ?? string.Empty;
        }

        [HttpGet]
        public IActionResult GetTheme()
        {
            // Retrieve the current user ID
            var userId = GetCurrentUserId();
            ThemeEntity theme = new ThemeEntity();

            // Check if the user is authenticated
            if (string.IsNullOrEmpty(userId))
            {
                var notLoggedUser = "Empty";
                theme = _themeRepository.GetTheme(notLoggedUser);
            }
            else
            {
                theme = _themeRepository.GetTheme(userId);
            }
            return View("NewEdit", theme);
        }

        [HttpGet]
        public string GetHeaderFooterBGColor()
        {
            ThemeEntity themeEntity;
            var userId = GetCurrentUserId();
            string testId = "1";

            if (string.IsNullOrEmpty(userId))
            {
                themeEntity = _themeRepository.GetTheme(userId);

            }
            else
            {
                themeEntity = _themeRepository.GetTheme(userId);
            }

            // return PartialView("_ThemePartial", themeEntity);
            return themeEntity.HeaderFooterBGColor;
        }

        [HttpGet]
        public string GetHeaderFooterColor()
        {
            ThemeEntity themeEntity;
            var userId = GetCurrentUserId();
            string testId = "1";

            if (string.IsNullOrEmpty(userId))
            {
                themeEntity = _themeRepository.GetTheme(userId);

            }
            else
            {
                themeEntity = _themeRepository.GetTheme(userId);
            }

            // return PartialView("_ThemePartial", themeEntity);
            return themeEntity.HeaderFooterColor;
        }

        [HttpGet]
        public string GetBodyBGColor()
        {
            ThemeEntity themeEntity;
            var userId = GetCurrentUserId();
            string testId = "1";

            if (string.IsNullOrEmpty(userId))
            {
                themeEntity = _themeRepository.GetTheme(userId);

            }
            else
            {
                themeEntity = _themeRepository.GetTheme(userId);
            }

            // return PartialView("_ThemePartial", themeEntity);
            return themeEntity.BodyBGColor;
        }
        [HttpGet]
        public string GetBodyColor()
        {
            ThemeEntity themeEntity;
            var userId = GetCurrentUserId();
            string testId = "1";

            if (string.IsNullOrEmpty(userId))
            {
                themeEntity = _themeRepository.GetTheme(userId);

            }
            else
            {
                themeEntity = _themeRepository.GetTheme(userId);
            }

            // return PartialView("_ThemePartial", themeEntity);
            return themeEntity.BodyColor;
        }
        [HttpPost]
        public IActionResult updateDepartmentTheme(ThemeEntity theme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ThemeRepository _DbEmployee = new ThemeRepository();
                    if (_DbEmployee.updateDepartmentTheme(theme))
                    {

                        return View("NewEdit", theme);
                    }
                }
                return View("NewEdit", theme);
            }
            catch
            {
                return View("NewEdit", theme);
            }
        }



    }
}