using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlocXChange.DataContext;
using Microsoft.AspNetCore.Mvc;
using BlocXChange.ViewModels;
using BlocXChange.Models;
using BlocXChange.Class;
using Microsoft.AspNetCore.Http;

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
            RandomKey.GetRandomKey(6);
            return View();
        }

        [HttpPost]
        public IActionResult NewGame(NewGameViewModel model)
        {
            if(ModelState.IsValid)
            {
                using (var db = new BlocXChangeDBContext())
                {
                    if(db.Games.FirstOrDefault(u => u.GameID == model.GameID) != null) // ID 중복 확인
                    {
                        ModelState.AddModelError("", "다른 ID를 사용해주세요");
                        return View(model);
                    }

                    // ID 미 중복시
                    string newGameKey = RandomKey.GetRandomKey(6);

                    while(db.Games.FirstOrDefault(u => u.GameKey == newGameKey) != null)
                    {
                        newGameKey = RandomKey.GetRandomKey(6);
                    }

                    Game newGame = new Game
                    {
                        GameID = model.GameID,
                        GamePassword = model.GamePassword,
                        GameKey = newGameKey,
                        InitialTime = DateTime.Now,
                        SuspendedTicks = 0
                    };
                    db.Games.Add(newGame);

                    var GenData = new GenerateGameData(newGame);
                    foreach(var i in GenData.GetStocks()) // 주가 데이터 생성
                    {
                        db.Stocks.Add(i);
                    }
                    foreach(var i in GenData.GetFluctuations()) // 주가 변동 데이터 생성
                    {
                        db.Fluctuations.Add(i);
                    }
                    
                    db.SaveChanges();

                    HttpContext.Session.SetString("GAME_MASTER_KEY", newGameKey);
                    return Redirect("Play/?GameKey=" + newGameKey);
                    
                }
            }
            return View(model);
        }

        public IActionResult EnterGame()
        {
            return Redirect("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GameKey"></param>
        /// <returns></returns>
        public IActionResult Play(string GameKey)
        {
            if(HttpContext.Session.GetString("GAME_MASTER_KEY") != GameKey)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}