using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHangMan
{
    public class Display
    {
        static string[] displayInfo = GetDisplayInfo();
        static int printLine;
        static public int lastLine;

        public Display()
        {
            Console.WindowHeight = 40;
        }
        
        static string[] GetDisplayInfo()
        {
            var input = new List<string> { Properties.Resources.Display };

            string tempInput = input[0];

            string[] displayData = tempInput.Split('\n');

            return displayData;
        }
        
        public static void UpdateDisplay(int livesRemaining)
        {
            Console.Clear();
            SetLinesToPrint(livesRemaining);

            while (printLine <= lastLine)
            {
                Console.WriteLine(displayInfo[printLine]);
                printLine++;
            }

            Console.WriteLine();

            if (livesRemaining > 0)
            {
                Console.WriteLine($"Solution:{Game.solution}");
                DisplayAttemptAndLives(livesRemaining);
                DisplayGuessMessage(Game.currentGuess);
            }
        }
        
        static void SetLinesToPrint(int screen)
        {
            switch (screen)
            {
                case -1:
                    printLine = 2;
                    lastLine = 30;
                    break;
                case 5:
                    printLine = 33;
                    lastLine = 51;
                    break;
                case 4:
                    printLine = 55;
                    lastLine = 73;
                    break;
                case 3:
                    printLine = 77;
                    lastLine = 95;
                    break;
                case 2:
                    printLine = 99;
                    lastLine = 117;
                    break;
                case 1:
                    printLine = 121;
                    lastLine = 139;
                    break;
                case 0:
                    printLine = 143;
                    lastLine = 172;
                    break;
            }
        }

        static void DisplayAttemptAndLives(int livesRemaining)
        {
            if (Game.lettersTried.Count == 0)
            {
                Console.Write("You have made no guesses yet.");
            }
            else
            {
                Console.Write($"So far you have tried: ");
                foreach (var item in Game.lettersTried)
                {
                    Console.Write(item + "  ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"You have {livesRemaining} lives remaining");
        }

        static void DisplayGuessMessage(char guess)
        {
            switch (Game.gameSelection)
            {
                case 0:
                    Console.Write("Please guess a letter: ");
                    break;
                case 1:
                    Console.WriteLine($"Your entry of {guess} is invalid");
                    Console.Write("Please guess a letter: ");
                    break;
                case 2:
                    Console.WriteLine($"You have already guessed {guess}. Try again!");
                    Console.Write("Please guess another letter: ");
                    break;
            }
        }

        public static void DisplayEndGame(int livesRemaining)
        {
            if (livesRemaining > 0)
            {
                Console.WriteLine("        WOO HOO!!!");
                Console.WriteLine("             YOU NAILED IT!!");
                Console.WriteLine();
                Console.WriteLine("    THE ANSWER WAS:");
                Console.WriteLine("                    " + Game.solution + " !! !! !!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Brought to you by Barry The Brilliant!");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press 'Enter' or 'Return' to end game");
            Console.Read();
        }
    }
}
