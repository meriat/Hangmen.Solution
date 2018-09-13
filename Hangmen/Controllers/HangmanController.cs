using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Hangmen.Models;

namespace Hangmen.Controllers
{
  public class HangmanController : Controller
  {
    public static List <string> wordList = new List <string> {"hello", "epicodus", "hyewon", "tamagotchi", "meria", "skye"};
    public static TargetWordGenerator generator = new TargetWordGenerator(wordList);
    [HttpGet("/hangman")]
    public ActionResult Index()
    {
      return View("Index", generator.targetWord);
    }
    [HttpPost("/hangman")]
    public ActionResult GuessLetter()
    {
      char newLetter = char.Parse(Request.Form["guessLetter"]);
      if (Guess.CheckDuplicate(newLetter) == false)
      {
        //make a new Guess instance and update page
        Guess newGuess = new Guess(newLetter);
        if(targetWord.Contains(newLetter))
        {
          
        }
      }
      else
      {
        return View("Index", generator.targetWord);
      }
    }
  }
}
