// Predefined words = List <string> predefinedWords;
//
// class TargetWordGenerator
// {
//   private predefinedWords;
//   private targetWord;
//
//   public string targetWordGenerate
//   {
//
//   }
// }

using System;
using System.Collections.Generic;

namespace Hangmen.Models
{
  public class TargetWordGenerator
  {
    public List<string> predefinedWords {get; set;}
    public string targetWord {get;}

    public TargetWordGenerator(List<string> words)
    {
      predefinedWords = words;
      Random rand = new Random();
      int predefinedWordsLength = predefinedWords.Count;
      int randomNumber = rand.Next(predefinedWordsLength);
      targetWord = predefinedWords[randomNumber];
    }
  }
}
