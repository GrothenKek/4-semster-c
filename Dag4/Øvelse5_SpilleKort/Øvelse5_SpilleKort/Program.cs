using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse5_SpilleKort
{
    class Program
    {
        static void Main(string[] args)
        {
            Card c;
            Deck deck = new Deck();
            deck.Add(c = new Card("ace", Card.Color.Clubs));
            deck.Add(c = new Card("ace", Card.Color.Diamonds));
            deck.Add(c = new Card("ace", Card.Color.Hearts));
            deck.Add(c = new Card("ace", Card.Color.Spades));
            Display(deck);
            Console.ReadLine();
           
        }
        public static void Display(Collection<Card> cs)
        {
            Console.WriteLine();
            foreach (Card item in cs)
            {
                Console.WriteLine(item.value + " " + item.color);
            }
        }

    }

    

    public class Deck : Collection<Card>
    {

    }


    public class Card {
        Color c = new Color();
        String Value;
        public Card(String x, Color c) {
            this.Value = x;
            this.c = c;
        }



        public string value
        {
            get { return Value; }
            set { Value = value; }
        }

        public String color
        {
            get { return c.ToString(); }

        }



        public enum Color
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        };





    }
    





}
