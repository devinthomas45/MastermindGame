using System;
using System.Collections.Generic;
using System.Text;

namespace MastermindGame
{
    public class MastemindGame
    {
        private List<int> AnswerCombination { get; set; } = new List<int>(); //Holds random generated answer combination
        private string CorrectCombination { get; set; } = string.Empty; //Holds (+) if number is correct and in correct position
        private string IncorrectCombination { get; set; } = string.Empty; // Holds (-) if number is correct but in wrong position

        public MastemindGame()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            AnswerCombination.Clear();
            ClearCombinations();
        }
        public void StartGame()
        {
            Console.WriteLine("---------------------------------------------------------");

            Console.WriteLine("\nWelcome to Mastermind!\n");
            GetRandomNumbers();

            //Payer has 10 attempts to get correct answer : "++++"
            var attempts = 1;
            bool reachedMaxAttempts;
            do
            {
                reachedMaxAttempts = attempts == 10;

                //Get users input of 4 numbers 1-6
                var combinationNumberList = GetUserInput(attempts);

                var results = GetResults(combinationNumberList);

                Console.WriteLine($"Results: {results}");
                Console.WriteLine("---------------------------------------------------------");
                if (results == "++++")
                {
                    DisplayWinMessage();
                    break;
                }

                attempts++;


            } while (!reachedMaxAttempts);

            if (reachedMaxAttempts)
            {
                DisplayLoseMessage();
            }
        }
        private void RetryMessage()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Would you like to try again? (Y/N)");

            var userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput)) return;

            var playAgain = userInput.Equals("Y") || userInput.Equals("y");

            if (playAgain)
            {
                StartGame();
            }

        }
        private void DisplayLoseMessage()
        {
            Console.WriteLine("You lose, please try again");
            RetryMessage();
        }
        private void DisplayWinMessage()
        {
            Console.WriteLine("Congrats! You won!!!!");
            RetryMessage();
        }
        private List<int> GetUserInput(int attempt)
        {
            Console.WriteLine("Enter 4 digit combination between 1 and 6\tAttempt:" + attempt.ToString());

            var combination = Console.ReadLine();

            if (combination.Length != 4)
            {
                throw new Exception("Please input 4 digits");
            }

            var charArray = combination.ToCharArray();

            var combinationNumberList = new List<int>(); //this list holds users input

            foreach (var character in charArray)
            {
                var number = Int32.Parse(character.ToString());
                combinationNumberList.Add(number);
            }
            return combinationNumberList;
        }
        private string GetResults(List<int> combinationNumberList)
        {
            //Add minus (-) if number is correct but in wrong position
            //Add plus (+) if number is correct and in correct position
            var results = string.Empty;

            ClearCombinations();

            for (int i = 0; i < combinationNumberList.Count; i++)
            {
                if (AnswerCombination[i] == combinationNumberList[i])
                {
                    CorrectCombination += "+";
                }

                if (AnswerCombination[i] != combinationNumberList[i] && AnswerCombination.Contains(combinationNumberList[i]))
                {
                    IncorrectCombination += "-";
                }

            }

            results = CorrectCombination + IncorrectCombination;
            return results;
        }
        private List<int> GetRandomNumbers()
        {
            ClearAnswers();

            do
            {
                var randomNumber = GetRandomNumber();

                if (!AnswerCombination.Contains(randomNumber))
                {
                    AnswerCombination.Add(randomNumber);
                }

            } while (AnswerCombination.Count <= 3);

            var randomNumbersString = string.Empty;

            foreach (var number in AnswerCombination)
            {
                randomNumbersString += number;
            }
            //Console.WriteLine($"Answer: {randomNumbersString}"); //Uncomment to show answer
            Console.WriteLine("---------------------------------------------------------");
            return AnswerCombination;
        }
        private int GetRandomNumber()
        {
            var randomNumber = new Random();

            return randomNumber.Next(1, 6);
        }
        private void ClearAnswers()
        {
            AnswerCombination = new List<int>();
        }
        private void ClearCombinations()
        {
            CorrectCombination = string.Empty;
            IncorrectCombination = string.Empty;
        }
    }
}
