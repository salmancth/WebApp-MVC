using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;


namespace WebApp.Controllers
{
    public class GuessingGameController : Controller
    {
		[HttpGet("GuessingGame")]
		public IActionResult GuessingGame()
        {
			HttpContext.Session.SetInt32("randNum",new Random().Next(0, 100));
			return View();
        }

		[HttpPost("GuessingGame")]
		public IActionResult GuessingGame(int userInput) 
		{
			ViewBag.ResultMessage = null;
			int randNum = (int)HttpContext.Session.GetInt32("randNum");
			if ((userInput < 0) || (userInput > 100))
				ViewBag.ResultMessage = "You should only use number between 1 to 100, other numbers are invalid";
			else if (userInput > randNum)
				ViewBag.ResultMessage = $"{userInput} is Bigger than the number you guessed. You can guess again";
			else if (userInput < randNum)
				ViewBag.ResultMessage = $"{userInput} is smaller than the  number you guessed";
			else if (userInput == randNum)
				ViewBag.ResultMessage = $"You got it! You found the right number :{randNum}.";
			return View();
		}
	}
}