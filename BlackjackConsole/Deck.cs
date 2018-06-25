using System;
using System.Collections.Generic;
using System.Text;

namespace BlackjackConsole{
    class Deck {
        public List<Card> Cards { get; set; }

        public void Shuffle() {
            int n = Cards.Count;
            Random rng = new Random();
            while(n > 1) {
                n--;
                int k = rng.Next(n + 1);
                Card v = Cards[k]; //set card to random index
                Cards[k] = Cards[n]; //set random card to the end card
                Cards[n] = v; //set last card to random card;
            }
        }

        public void FillDeck() {
            Cards = new List<Card>();
            for(int i =0; i < 51; i++) {
                Suit newSuit = (Suit)(i % 4);
                Value newValue = (Value)(i % 13 + 1);
                if(newValue > (Value)10) {
                    newValue = (Value)10;
                }
                Cards.Add(new Card(newSuit, newValue));
            }
            Shuffle();

        }

        public Card GetNextCard() {
            if (Cards.Count < 1)
                FillDeck();
            Card c = Cards[0];
            Cards.RemoveAt(0);
            return c; 
        }
    }

}
