using System;
using System.Collections.Generic;
using Cards.Models;
using Cards.Services;

namespace Cards.Services.BlackJack
{
    public interface IBlackJack
    {
        void StartBlackJack();
        int PlayGame(int betAmount);
    }

    public class BlackJack : GameLogic, IBlackJack
    {
        public BlackJack()
        {
            GameMode = Enums.GameModes.BlackJack;
            this.CreateDeck();
        }

        public void StartBlackJack()
        {
            // Move to config later
            var totalMoney = 10;

            Console.Clear();
            while (GameMode == Enums.GameModes.BlackJack)
            {
                Console.Clear();
                Console.WriteLine($"Player Funds: ${totalMoney}");
                Console.Write("Enter your bet: ");
                var betString = Console.ReadLine();
                var bet = 0;

                try
                {
                    bet = int.Parse(betString);
                }
                catch { }

                if (bet > totalMoney)
                {
                    Console.WriteLine("Bet cannot be hire than total money");
                    Console.WriteLine("Press any key to continue...");
                }
                else
                {
                    bet += PlayGame(bet);
                }
            }
        }

        public int PlayGame(int betAmount)
        {
            Console.Clear();
            ShuffleDeck();

            var playerCards = new List<Card>();
            var dealerCards = new List<Card>();

            // Deal first two cards
            for (int i = 0; i < 2; i++)
            {
                playerCards.Add(DealSingleCard());
                dealerCards.Add(DealSingleCard());
            }

            Console.WriteLine("Dealer");

            DisplayCards(new List<Card> { dealerCards[0] });

            Console.WriteLine("\nPlayer");

            DisplayCards(playerCards);


            Console.WriteLine(@"
1) Hit
2) Stand");
            Console.Write("Hit or Stand: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Hit();
                    break;
                case "2":
                    Stand();
                    break;
            }

            return betAmount;
        }

        private Card Hit()
        {
            return new Card();
        }

        private void Stand()
        {

        }

        private Card DealSingleCard()
        {
            var card = Deck[0];
            Deck.RemoveAt(0);
            return card;
        }
    }
}