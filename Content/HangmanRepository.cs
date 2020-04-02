using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanRepository
    {
        public readonly List<HangmanContent> _wordDirectory = new List<HangmanContent>();
        public List<string> pullWords = new List<string>() { "car ", "fish", "house", "river", "dog", "bat", "cat", "rat", "bike", "king", "\n" +
            "cycle", "boggle", "injury", "funny", "jogging", "joking", "puppy", "quiz", "scratch", "subway", "\n"+
            "zombie", "witchcraft", "syndrome", "razzmatazz", "grogginess", "askew", "croquet", "espionage", "jiujitsu", "xylophone" };
        public string StartPlaying(HangmanContent pullWords)
        {
            int startingCount = _wordDirectory.Count;
            _wordDirectory.Add(pullWords);
            string levelSelected = (_wordDirectory.Count == startingCount) ? "You have now selected your level" : "Please select a level";
            return levelSelected;
        }
        public string PullWords()
        {
            var random = new Random();
            int index = random.Next(pullWords.Count);
            string ActiveWord = pullWords[index].ToString();
            return ActiveWord;
        }
        public int NumberOfLetter(string ActiveWord)
        {
            char[] letters = ActiveWord.ToCharArray();
            int number = letters.Length;
            return number;
        }

        public void PlayingTheGame(string activeWord)
        {
            char[] letter = new char[activeWord.Length];
            int lifeCount = 6;

            for (int w = 0; w < letter.Length; w++)
            {
                letter[w] = '-';
            }

            for (int w = 0; w < letter.Length; w++)//number of letters via underscores
            {
                Console.WriteLine(letter[w] + " ");
            }

            Console.WriteLine();

            do
            {
                int count = 0;
                do
                {
                    Console.WriteLine("What letter do you guess?");

                    char input = Console.ReadLine().ToCharArray()[0];

                    for (int w = 0; w < activeWord.Length; w++)
                    {
                        if (activeWord[w] == input)///if correct
                        {
                            count++; ///update count to check upon exit
                            letter[w] = input; ///replacing the dash

                            if (count == activeWord.Length)
                            {
                                Console.WriteLine($"Congratulations, the word was {activeWord}");
                                GameOver();
                            }

                            for (int l = 0; l < activeWord.Length; l++)
                            {
                                Console.WriteLine(letter[l] + " ");
                            }
                        }
                        else if (activeWord[w] != input)
                        {
                            lifeCount -= 1;
                            Console.WriteLine("That guess was incorrect.");
                        }
                    }
                    if (lifeCount == 0)
                    {
                        Console.WriteLine("You've run out of lives.");
                        GameOver();
                    }
                    Console.WriteLine();
                }
                while (count < activeWord.Length);
            }
            while (lifeCount > 0);

            GameOver();
        }

        public void GameOver()
        {
            Console.WriteLine("What would you like to do? \n" +
            "1) Play again.\n" +
            "2) Exit\n");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    PullWords();
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
