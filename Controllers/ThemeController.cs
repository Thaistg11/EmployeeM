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
                    bool result;
                    if (theme == null)
                    {
                        // Create new
                        result = _themeRepository.CreateDepartmentTheme(ThemeFromTheView, userId);
                    }
                    else
                    {
                        // Update existing
                        ThemeFromTheView.Id = theme.Id; // Make sure the ID is set
                        result = _themeRepository.UpdateDepartmentTheme(ThemeFromTheView);
                    }

                    if (result)
                    {
                        TempData["SuccessMessage"] = "Theme saved successfully!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to save theme.";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
            }

            return RedirectToAction("GetTheme");
        }

        [HttpGet]
        public string GetHeaderFooterBGColor()
        {
            ThemeEntity themeEntity;
            var userId = GetCurrentUserId();


            if (string.IsNullOrEmpty(userId))
            {
                themeEntity = _themeRepository.GetTheme(userId);
                return null;
            }
            else
            {
                themeEntity = _themeRepository.GetTheme(userId);
                if (themeEntity == null)
                {
                    return null;
                }
                else
                {
                    return themeEntity.HeaderFooterBGColor;
                }
            }   
            
        }

        [HttpGet]
        public string GetHeaderFooterColor()
        {
            ThemeEntity themeEntity;
            var userId = GetCurrentUserId();
           

            if (string.IsNullOrEmpty(userId))
            {
                themeEntity = _themeRepository.GetTheme(userId);
                return null;
            }
            else
            {
                themeEntity = _themeRepository.GetTheme(userId);
                if (themeEntity == null)
                {
                    return null;
                }
                else
                {
                    return themeEntity.HeaderFooterColor;
                }
            }
           

      
          
        }
        [HttpGet]
        public string GetBodyBGColor()
        {
            ThemeEntity themeEntity;
            var userId = GetCurrentUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }
            else
            {
                themeEntity = _themeRepository.GetTheme(userId);
                if (themeEntity == null)
                {
                    return null;
                }
                else
                {
                    return themeEntity.BodyBGColor;
                }
            }
            
        }

        [HttpGet]
        public string GetBodyColor()
        {
            ThemeEntity themeEntity;
            var userId = GetCurrentUserId();
           

            if (string.IsNullOrEmpty(userId))
            {
                themeEntity = _themeRepository.GetTheme(userId);
                return null;
            }
            else
            {
                themeEntity = _themeRepository.GetTheme(userId);
                if (themeEntity == null)
                {
                    return null;
                }
                else
                {
                    return themeEntity.BodyColor;
                }
            }
         
       
        }
 


    }
}