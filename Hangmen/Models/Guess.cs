using System;
using System.Collections.Generic;

namespace Hangmen.Models
{
  public class Guess
  {
    public char letter { get; set; }
    public static List<Guess> guesses = new List<Guess> {};
    public static string correctLetters = "";
    public static string incorrectLetters = "";
    public Guess(char newLetter)
    {
      letter = newLetter;
      guesses.Add(this);
    }
    public static bool CheckDuplicate(char newLetter)
    {
      //listName.Exists(condition) looks for an item which is matched with the condition, and if it succeed to find an item in the list, it will return true, otherwise, it will return false
      if(guesses.Exists(guess => guess.letter == newLetter) == true)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
