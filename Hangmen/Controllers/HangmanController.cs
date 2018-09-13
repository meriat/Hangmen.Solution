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
      if (Guess.correctLetters == "")
      {
        Guess.correctLetters = generator.InitializeCorrectLetters();
      }
      Dictionary <string, string> dict = new Dictionary<string, string>();
      dict.Add("gameOver", "false");
      dict.Add("correctLetters", Guess.correctLetters);
      dict.Add("incorrectLetters", Guess.incorrectLetters);
      return View("Index", dict);
    }

    [HttpPost("/hangman")]
    public ActionResult GuessLetter()
    {
      char newLetter = char.Parse(Request.Form["guessLetter"]);

      if (Guess.CheckDuplicate(newLetter) == false)
      {
        Dictionary <string, string> dict = new Dictionary<string, string>();
        dict.Add("gameOver", "false");
        //make a new Guess instance and update page
        Guess newGuess = new Guess(newLetter);
        if (generator.targetWord.Contains(newLetter.ToString()))
        {
          for(int i = 0; i < generator.targetWord.Length; i++)
          {
            if(generator.targetWord[i] == newLetter)
            {
              string first = Guess.correctLetters.Substring(0, i);
              string last = Guess.correctLetters.Substring(i+1);
              Guess.correctLetters = first+newLetter.ToString()+last;
            }
          }
        }
        else
        {
          Guess.incorrectLetters += newLetter.ToString();
          if(Guess.incorrectLetters.Length >= 6)
          {
            generator = new TargetWordGenerator(wordList);
            Guess.correctLetters="";
            Guess.incorrectLetters="";
            Guess.guesses.Clear();
            dict["gameOver"] = "true";
          }
        }

        dict.Add("correctLetters", Guess.correctLetters);
        dict.Add("incorrectLetters", Guess.incorrectLetters);
        return View("Index", dict);
      }
      else
      {
        Dictionary <string, string> dict = new Dictionary<string, string>();
        dict.Add("gameOver", "false");
        dict.Add("correctLetters", Guess.correctLetters);
        dict.Add("incorrectLetters", Guess.incorrectLetters);
        return View("Index", dict);
      }
    }
  }
}
