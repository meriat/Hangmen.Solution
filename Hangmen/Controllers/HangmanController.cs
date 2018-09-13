using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Hangmen.Models;

namespace Hangmen.Controllers
{
  public class HangmanController : Controller
  {
    [HttpGet("/hangman")]
    public ActionResult Index()
    {
      List <string> wordList = new List <string> {"hello", "epicodus", "hyewon", "tamagotchi", "meria", "skye"};
      TargetWordGenerator generator = new TargetWordGenerator(wordList);
      return View("Index", generator.targetWord);
    }
    [HttpPost("/hangman")]
    public ActionResult Guess()
    {
      
    }
  }
}
