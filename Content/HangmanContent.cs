using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanContent
    {
        public string ActiveWord { get; set; }
        public HangmanContent() { }
        public HangmanContent(string activeWord)
        {
            ActiveWord = activeWord;
        }
    }
    public class Player
    {
        public string Name { get; set; }
        private int lifeCount = 6;
        public int LifeCount { get { return lifeCount; } set { lifeCount = value; } }
        public Player() { }
        public Player(string name, int lifeCount)
        {
            Name = name;
            LifeCount = lifeCount;
        }
    }
}