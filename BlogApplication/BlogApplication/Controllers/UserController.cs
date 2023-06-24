using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using DataLayer.Models;

namespace BlogApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                return Json(new { success = true, user = user });
            }
            return Json(new { success = false });
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpPost("Edit/{id}")]
        public IActionResult Edit(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
                return Json(new { success = true, user = user });
            }
            return Json(new { success = false });
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.DeleteUser(id);
            return Json(new { success = true });
        }
    }
}
