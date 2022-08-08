using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHangMan
{
    internal class Game
    {
        public static string solution = "";
        public static string answer = Menu.selectedAnswer;
        public static int gameSelection = 0;
        public static char currentGuess = '`';
        public int lives = 5;
        public bool win = false;


        public static List<char> lettersTried = new List<char>();


        public Game()
        {
            DefineAnswer();
            InitialiseSolution();
        }

        static void DefineAnswer()
        {
            answer = answer.ToUpper();
            var checkAns = new List<char> { };
            checkAns.AddRange(answer);
        }

        static void InitialiseSolution()
        {
            while (solution.Length != (answer.Length * 2))
            {
                solution = solution + " _";
            }
        }

        public void UpdateTried()
        {
            lettersTried.Add(currentGuess);
        }
    }
}
