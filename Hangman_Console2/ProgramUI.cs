using Hangman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Console2
{
    public class ProgramUI
    {
        HangmanRepository _repository = new HangmanRepository();
        
        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
        {
            Console.WriteLine("Thanks for playing our game today.\n"+
                "Press any key to continue....");

            Console.ReadKey();

            _repository.PullWords();

        }
    }
}
