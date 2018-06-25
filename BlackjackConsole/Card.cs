using System;
using System.Collections.Generic;
using System.Text;

namespace BlackjackConsole{

    class Card {
        public Suit Suit { get; }
        public Value Value { get; set; }

        public Card(Suit s, Value value) {
            this.Suit = s;
            this.Value = value;
        }

        public override string ToString() {
            return ""+(int)Value;// + " of " + Suit;
        }

    }
}
