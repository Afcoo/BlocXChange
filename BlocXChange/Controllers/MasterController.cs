using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlocXChange.DataContext;
using Microsoft.AspNetCore.Mvc;
using BlocXChange.ViewModels;
using BlocXChange.Models;

namespace BlocXChange.Controllers
{
    public class MasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewGame(NewGameViewModel model)
        {
            if(ModelState.IsValid)
            {
                using (var db = new BlocXChangeDBContext())
                {
                    Game newGame = new Game();
                    newGame.GameID = model.GameID;
                    newGame.InitialTime = DateTime.Now;
                    newGame.SuspendedTicks = 0;

                    db.Games.Add(newGame);
                    db.SaveChanges();
                    return Redirect("Play");
                }
            }
            return View(model);
        }

        public IActionResult EnterGame()
        {
            return Redirect("Index");
        }

        public IActionResult Play()
        {
            return View();
        }
    }
}