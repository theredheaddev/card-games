using System;
using Cards.Services.BlackJack;

namespace cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(@"
                Welcome to the 'Console Cards'
                ------------------------------
                Enter a gamemode below:
                    1) Black Jack

                    0) Exit
                ");
                Console.Write("Enter your value: ");
                var answerString = Console.ReadLine();
                var answer = -1;
                try
                {
                    answer = int.Parse(answerString);
                }
                catch
                {
                }

                switch (answer)
                {
                    case 1:
                        var blackJack = new BlackJack();
                        blackJack.StartBlackJack();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
