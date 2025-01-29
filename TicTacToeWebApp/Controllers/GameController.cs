using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using TicTacToeWebApp.Models;

namespace TicTacToeWebApp.Controllers
{
    public class GameController : Controller
    {
        private static TicTacToe game = new TicTacToe();

        public IActionResult CreateNew()
        {
            // Initialize a new game
            game = new TicTacToe();
            return View(game);
        }

        public IActionResult MakeMove(int row, int col)
        {
            // Make a move and check the game result
            game.MakeMove(row, col);
            game.Result = game.CheckWin();
            return View("CreateNew", game);
        }

        public IActionResult SaveGame()
        {
            try
            {
                // Serialize the current game state to JSON
                var gameData = JsonConvert.SerializeObject(game, Formatting.Indented);

                // Save the game data to a file
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "GameSave.json");
                System.IO.File.WriteAllText(filePath, gameData);

                TempData["Message"] = "Game saved successfully!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed to save the game: {ex.Message}";
            }

            return RedirectToAction("CreateNew");
        }

        public IActionResult OpenSavedGames()
        {
            try
            {
                // File path for the saved game
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "GameSave.json");

                if (System.IO.File.Exists(filePath))
                {
                    // Read the JSON from the file
                    var gameData = System.IO.File.ReadAllText(filePath);

                    // Deserialize the JSON to the game object
                    game = JsonConvert.DeserializeObject<TicTacToe>(gameData);

                    TempData["Message"] = "Game loaded successfully!";
                }
                else
                {
                    TempData["Error"] = "No saved game found.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed to load the game: {ex.Message}";
            }

            return View("CreateNew", game);
        }
    }
}
