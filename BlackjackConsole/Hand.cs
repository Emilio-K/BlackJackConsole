using System;
using System.Collections.Generic;
using System.Text;

namespace BlackjackConsole{
    class Hand{
        public List<Card> Cards { get; set; }
        public int CurrentValue { get; set; }
        
        public Hand() {
            Cards = new List<Card>();
        }

        public void Add(Card c) {
            
            if (c.Value == Value.Ace && (CurrentValue + 11 <= 21)) {
                CurrentValue += 11;
                c.Value = (Value)11;
            } else {
                CurrentValue += (int)c.Value;
            }
            Cards.Add(c);
        }

        public Boolean Over21() {
            return CurrentValue > 21;
        }

        public int NumCards() {
            return Cards.Count;
        }
    }
}
