using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHangMan
{
    public class Menu
    {
        static int menuSelection = 0;
        static int maxOptions;
        public static string selectedAnswer;

        public Menu()
        {
            string[] options = GetList();

            do
            {
                Display.UpdateDisplay(-1);
                DisplayChoice();
                GetChoice();

            } while (menuSelection !< 1);

            selectedAnswer = options[menuSelection -1];

        }

        public string[] GetList()
        {
            var input = new List<string> { Properties.Resources.WordList };

            string tempInput = input[0];

            string[] words = tempInput.Split("\r\n");

            maxOptions = words.Count();

            return words;
        }

        public void DisplayChoice()
        {
            Console.WriteLine($"You have {maxOptions} possible words to choose from");

            if (menuSelection == 0)
            {
                Console.Write($"Please choose a level from 1 to {maxOptions}: ");
            }
            else
            {
                Console.WriteLine("You have made an invalid choice!");
                Console.Write($"Please choose a level from 1 to {maxOptions}: ");
            }
        }

        public void GetChoice()
        {
            var input = Console.ReadLine();
            Int32.TryParse(input, out menuSelection);

            if (menuSelection < 1 || menuSelection > maxOptions)
            {
                menuSelection = -1;
                Console.WriteLine();
            }
        }

    }
}
