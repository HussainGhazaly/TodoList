

using DiceRollGame.UserCommunication;

namespace DiceRollGame.Game
{
    public class GuessingGame
    {
        private readonly Dice _dice;
        private const int InitialTries = 3;

        public GuessingGame(Dice dice)
        {
            _dice = dice;
        }

        public GameResult Play()
        {
            var diceRollResult = _dice.Roll(); //start rolling :))
            Console.WriteLine($"Dice rolled. Guess what number it shows in {InitialTries} tries. ");

            var triesLeft = InitialTries;
            while (triesLeft > 0)
            {
                var guess = ConsoleReader.ReadInteger("Enter a number: ");
                // Now we want to check if the number entered by the user == to the rolled dice :) 

                if (guess == diceRollResult)
                {
                    return GameResult.Victory;
                }
                Console.WriteLine("Wrong number. ");
                --triesLeft;
            }
            return GameResult.Loss;

        }

        public static void PrintResult(GameResult gameResult)
        {
            // Ternary condtion 3 oprands
            string message = gameResult == GameResult.Victory
                ? "You win!"
                : "You Lose :(";
            Console.WriteLine(message);
        }
    }
}
