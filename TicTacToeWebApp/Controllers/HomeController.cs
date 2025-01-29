using Microsoft.AspNetCore.Mvc;

namespace TicTacToeWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Settings()
        {
            // This will render the Settings view
            return View();
        }

        public IActionResult Exit()
        {
            // Redirect to a goodbye or exit page, or close the browser if required
            return Content("Thank you for using the Tic-Tac-Toe Web App! You can close the browser to exit.");
        }

    }
}
