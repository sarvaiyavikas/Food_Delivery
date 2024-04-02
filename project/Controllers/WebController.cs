using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Controllers
{
    public class WebController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WebController(ApplicationDbContext _context)
        {
                this._context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            IEnumerable<User> users = _context .Users;
            return View(users);
            
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User_login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            HttpContext.Session.SetString("Email", model.Email);
            if (user != null)
            {
                // Log in the user
                // Redirect to home page or any other page after successful login
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Incorrect username or password");
                return View(model);
            }
        }

        //---------------------------------------------------------------------
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email || u.Number == user.Number);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email or number already exists!");
                    return View();
                }

                if (user.Password != user.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Confirm password not matched!");
                    return View();
                }

                user.Password = HashPassword(user.Password); // Implement hash function as needed

                _context.Users.Add(user);
                _context.SaveChanges();

                // Redirect to home or login page
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
        private string HashPassword(string password)
        {
            // Implement your password hashing logic here
            return password; // For demonstration, return plain password
        }
        ////public IActionResult Registration()
        ////{
        ////    return View();
        ////}

        //---------------------------------------------------------------
        public IActionResult ShoppingCart()
        {
            return View();
        }
        public IActionResult MyProfile()
        {
            return View();
        }
        public IActionResult CheCkout()
        {
            return View();
        }
        public IActionResult YourAddress()
        {
            return View();
        }
        public IActionResult UpdateProfile()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }
    }
}
