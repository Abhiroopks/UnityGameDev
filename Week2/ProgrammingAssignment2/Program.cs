using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment2
{
    /// <summary>
    /// Programming Assignment 2 solution
    /// </summary>
    class Program
    {
        /// <summary>
        /// Deals 2 cards to 3 players and displays cards for players
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            // print welcome message
            Console.WriteLine("Welcome to the card game!");
            // create and shuffle a deck
            Deck deck = new Deck();

            // deal 2 cards each to 3 players (deal properly, dealing
            // the first card to each player before dealing the
            // second card to each player)
            Card[,] cards = new Card[2,3];
            for (int i = 0; i < 2; i++){ //card 1 before card 2
                for(int j = 0; j < 3; j++){ //player order after card order
                    cards[i, j] = deck.TakeTopCard();
                }
            }


            // flip all the cards over
            /*
            for (int i = 0; i < 2; i++) { //card 1 before card 2
                for (int j = 0; j < 3; j++) { //player order after card order
                    cards[i, j] = deck.TakeTopCard();
                }
            }
            */

            foreach(Card card in cards) {
                card.FlipOver();
            }

            // print the cards for player 1
            Console.WriteLine("\nPlayer 1 Cards:");
            for(int i = 0; i < 2; i++) {
                Console.WriteLine(cards[i,0].Rank + " of " + cards[i, 0].Suit);
            }

            // print the cards for player 2
            Console.WriteLine("\nPlayer 2 Cards:");

            for (int i = 0; i < 2; i++) {
                Console.WriteLine(cards[i, 1].Rank + " of " + cards[i, 1].Suit);
            }
            // print the cards for player 3
            Console.WriteLine("\nPlayer 3 Cards:");

            for (int i = 0; i < 2; i++) {
                Console.WriteLine(cards[i, 2].Rank + " of " + cards[i, 2].Suit);
            }

            Console.WriteLine("\nPress enter to exit program");
            Console.ReadLine();
           
        }
    }
}
