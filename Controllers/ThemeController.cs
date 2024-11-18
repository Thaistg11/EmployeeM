using EmployeeM.Data;
using EmployeeM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace EmployeeM.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ThemeRepository _themeRepository;

        public ThemeController (IHttpContextAccessor httpContextAccessor, ThemeRepository themeRepository)
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
            var UserId = GetCurrentUserId();
            ThemeEntity theme = new ThemeEntity();

            // Check if the user is authenticated
            if (string.IsNullOrEmpty(UserId))
            {
                var notLoggedUser = "Empty";
                theme = _themeRepository.GetTheme(notLoggedUser);
            }
            else
            {
                theme = _themeRepository.GetTheme(UserId);
            }
            return View("Index", theme);
        }
        [HttpPost]
        public IActionResult UpdateOrCreateDepartmentTheme(ThemeEntity ThemeFromTheView)
        {
            var userId = GetCurrentUserId();

            // Retrieve the theme associated with the user
            var theme = _themeRepository.GetTheme(userId);

            try
            {
                if (ModelState.IsValid)
                {
                    var themeRepository = new ThemeRepository();

                    if (theme == null)
                    {
                        Console.WriteLine("Condition is true");
                        // Theme is empty: call the Create function
                        themeRepository.CreateDepartmentTheme(ThemeFromTheView, userId);
                        {
                            // Retrieve the new theme just created
                            var themeUpdated = _themeRepository.GetTheme(userId);
                            return View("Index", themeUpdated);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Condition is not  true 123");
                        // Theme exists: call the Update function
                        themeRepository.UpdateDepartmentTheme(ThemeFromTheView);

                        // Retrieve the new theme if updated values
                        var themeUpdated = _themeRepository.GetTheme(userId);
                            return View("Index", themeUpdated);

                    }
                }
                return View("Index-error");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return View("Index-error-catch");
            }
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
 


    }
}