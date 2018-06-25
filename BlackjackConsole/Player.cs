using System;
using System.Collections.Generic;
using System.Text;

namespace BlackjackConsole{
    class Player{
        public Hand Hand { get; set; }
        public int Score { get; set; }


        public Player() {
            Hand = new Hand();
            Score = 0;
        }

        public int GetHandValue() {

            return Hand.CurrentValue;
        }

        public void Hit(Card c) {
            Hand.Add(c);
            
        }

        public Boolean BlackJack() {
            return (Hand.NumCards() == 2 && GetHandValue() == 21);
        }

        public void ShowHand() {
            foreach(Card c in Hand.Cards) {
                Console.Write(c + " ");
            }
        }

        public void ClearHand() {
            Hand = new Hand();
        }

        public Boolean Busted() {
            return Hand.Over21();
        }

        public void IncreaseScore() {
            Score++;
        }
    }
}
