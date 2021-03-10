using System.Collections.Generic;
using Cards.Models;
using System.Linq;
using System;

namespace Cards.Services
{
    public interface IGameLogic
    {
        void CreateDeck();
        void ShuffleDeck();

        void ShowDeck();
    }

    public class GameLogic : IGameLogic
    {
        public List<Card> Deck { get; set; }

        public void CreateDeck()
        {
            var hearts = CreateHearts();
            var diamonds = CreateDiamonds();
            var spades = CreateSpades();
            var clubs = CreateClubs();

            this.Deck = new List<Card>()
                .Concat(hearts)
                .Concat(diamonds)
                .Concat(spades)
                .Concat(clubs)
                .ToList();

        }

        public void ShuffleDeck()
        {
            var shuffledDeck = new List<Card>();
            var dummyDeck = this.Deck;

            while (dummyDeck.Count > 0)
            {
                var randomIndex = new Random().Next(dummyDeck.Count);

                shuffledDeck.Add(dummyDeck[randomIndex]);
                dummyDeck.RemoveAt(randomIndex);

            }

            this.Deck = shuffledDeck;
        }

        public void ShowDeck()
        {
            foreach (var card in Deck)
            {
                Console.WriteLine($"{card.Text} {card.CardType.ToString()}");
            }
        }

        private List<Card> CreateHearts()
        {
            return CreateCards(CardType.Hearts);
        }

        private List<Card> CreateDiamonds()
        {
            return CreateCards(CardType.Diamonds);
        }

        private List<Card> CreateSpades()
        {
            return CreateCards(CardType.Spades);
        }

        private List<Card> CreateClubs()
        {
            return CreateCards(CardType.Clubs);
        }

        private List<Card> CreateCards(CardType type)
        {
            var cards = new List<Card>();

            for (int i = 1; i <= 10; i++)
            {

                var card = new Card
                {
                    Value = i,
                    Text = i == 1 ? "A" : i.ToString(),
                    CardType = type
                };

                cards.Add(card);
            }

            cards.Add(new Card { Value = 10, Text = "J", CardType = type });
            cards.Add(new Card { Value = 10, Text = "Q", CardType = type });
            cards.Add(new Card { Value = 10, Text = "K", CardType = type });

            return cards;
        }
    }
}