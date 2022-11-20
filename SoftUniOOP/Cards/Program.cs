using System;
using System.Collections.Generic;

namespace Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var validCards = new List<Card>();

            foreach (var card in cards)
            {
                var info = card.Split();
                var face = info[0];
                var suits = info[1];
                try
                {
                    var newCard = new Card(face, suits);
                    validCards.Add(newCard);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(string.Join(" ", validCards));
        }
    }

    public class Card
    {
        private string face;
        private string suits;

        public Card(string face, string suits)
        {
            Face = face;
            Suits = suits;
        }

        public string Face
        {
            get => face;
            set
            {
                var validFaces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

                if (!validFaces.Contains(value))
                {
                    ThrowError();
                }
                face = value;
            }
        }

        public string Suits
        {
            get => suits;
            set
            {
                var spades = '\u2660';
                var hearts = '\u2665';
                var clubs = '\u2663';
                var diamonds = '\u2666';
                switch (value)
                {
                    case "S":
                        suits = spades.ToString();
                        break;
                    case "H":
                        suits = hearts.ToString();
                        break;
                    case "C":
                        suits = clubs.ToString();
                        break;
                    case "D":
                        suits = diamonds.ToString();
                        break;
                    default:
                        ThrowError();
                        break;
                }
            }
        }

        private static void ThrowError()
        {
            throw new ArgumentException("Invalid card!");
        }

        public override string ToString()
            => $"[{face}{suits}]";
    }
}
