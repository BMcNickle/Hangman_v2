using System;
using System.Collections.Generic;

namespace NewHangMan
{
    public class Program
    {
        static bool validEntry;

        static void Main(string[] args)
        {

            var newDisplay = new Display();
            var newMenu = new Menu();
            var newGame = new Game();

            while (newGame.lives > 0 && newGame.win != true)
            {
                Game.gameSelection = 0;

                do
                {
                    Display.UpdateDisplay(newGame.lives);
                    GetGuess();
                } while (validEntry == false);

                if (!CheckGuessCorrect(Game.currentGuess))
                {
                    Game.lettersTried.Add(Game.currentGuess);
                    newGame.lives--;
                }
                else
                {
                    newGame.win = CheckWin(Game.answer, Game.solution);
                }

                Display.UpdateDisplay(newGame.lives);
            }

            Display.DisplayEndGame(newGame.lives);
        }

        static void GetGuess()
        {
            validEntry = true;
            char guess;
            string guessInput = Console.ReadLine();

            guessInput = guessInput.Trim();

            if (guessInput == "")
            {
                guessInput = " ";
            }

            guess = Char.ToUpper(guessInput[0]);
            ValidateGuess(guess);
        }

        static void ValidateGuess(char guess)
        {
            if (!char.IsLetter(guess))
            {
                validEntry = false;
                Game.gameSelection = 1;
            }
            else
            {
                CheckRepeatedGuess(guess);
            }
            Game.currentGuess = guess;
        }

        static void CheckRepeatedGuess(char guess)
        {
            int triedCount = Game.lettersTried.Count;
            char checkGuess;
            int checkIndex = 0;

            while (checkIndex < triedCount)
            {
                checkGuess = Game.lettersTried[checkIndex];

                if (guess.CompareTo(checkGuess) == 0)
                {
                    checkIndex = triedCount;
                    Game.gameSelection = 2;
                    validEntry = false;
                }

                checkIndex++;
            }
        }

        static bool CheckGuessCorrect(char guess)
        {
            string answer = Game.answer;
            bool guessCorrect = false;
            char checkGuess;
            int checkIndex = 0;
            var checkAns = new List<char> { };

            checkAns.AddRange(answer);

            while (checkIndex < answer.Length)
            {
                checkGuess = checkAns[checkIndex];

                if (guess.CompareTo(checkGuess) == 0)
                {
                    UpdateSolution(Game.solution, checkIndex, guess);
                    guessCorrect = true;
                }

                checkIndex++;
            }

            return guessCorrect;
        }

        static void UpdateSolution(string oldSolution, int index, char newChar)
        {
            index = index * 2 + 1;

            char[] chars = oldSolution.ToCharArray();

            chars[index] = newChar;

            Game.solution = new string(chars);
        }

        static bool CheckWin(string correctAnswer, string solutionToCheck)
        {
            string[] tempResult = solutionToCheck.Split(' ');
            solutionToCheck = "";
            foreach (var letter in tempResult)
            {
                solutionToCheck = solutionToCheck + letter;
            }

            bool result = Equals(correctAnswer, solutionToCheck);

            return result;
        }
    }
}