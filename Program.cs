using System;
using Cards.Services;

namespace cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameLogic = new GameLogic();
            gameLogic.CreateDeck();
            gameLogic.ShuffleDeck();
            gameLogic.ShowDeck();
        }
    }
}
