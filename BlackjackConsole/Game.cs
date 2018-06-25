using System;
using System.Collections.Generic;
using System.Text;

namespace BlackjackConsole{
    class Game{
        Player dealer = new Player();
        Player human = new Player();
        Deck deck = new Deck();

        public void StartGame() {
            deck.FillDeck();
            string input = "y";
            int size = deck.Cards.Count;

            while (String.Equals(input,"y")) {
                DealStart();
                DisplayScores();
                PlayRound();
                Console.WriteLine("Keep playing? y/n");
                input = getInputContinue();
            }
        }
        // check if single round is over by seeing if any player busted, and if they didnt bust see if they want to hit.
        public Boolean RoundEnd(string s) {
            if(human.Busted() || dealer.Busted()) {
                Console.WriteLine("he");
                return true;
            } else {
                if (String.Equals(s, "s"))
                    return true;
                else
                    return false;
            }
        }

        public void DealStart() {
            human.Hit(deck.GetNextCard());
            human.Hit(deck.GetNextCard());
            dealer.Hit(deck.GetNextCard());
        }

        public void ShowBothHands() {
            ShowDealerCards();
            Console.WriteLine("\n");
            ShowPlayerCards();
        }

        public void ShowPlayerCards() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Your cards:   ");
            human.ShowHand();
        }

        public void ShowDealerCards() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Dealer cards:   ");
            dealer.ShowHand();
        }

        public void DealerHit() {
            while (dealer.GetHandValue()<16) {
                dealer.Hit(deck.GetNextCard());
            }
        }

        public void Stayed() {
            DealerHit();
            ShowDealerCards();
            Console.ForegroundColor = ConsoleColor.White;
            if (dealer.GetHandValue() > 21) {
                Console.WriteLine("\n\nDealer Busted, you win!");
                dealer.IncreaseScore();
            } else {
                if (dealer.GetHandValue() > human.GetHandValue()) {
                    Console.WriteLine("\n\nDealer won. You suck.");
                    dealer.IncreaseScore();
                } else if (dealer.GetHandValue() == human.GetHandValue()) {
                    Console.WriteLine("Tie, pushed.");
                } else {
                    Console.WriteLine("\n\nYou won, you got a little lucky...");
                    human.IncreaseScore();
                }
            }
            Console.WriteLine("\n\n");

        }

        public void Restart() {
            human.ClearHand();
            dealer.ClearHand();
        }

        public void DisplayScores() {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Your score: " + human.Score);
            Console.WriteLine("Dealer score: " + dealer.Score);
            Console.WriteLine("-----------------------------------------\n");
        }

        public string getInputContinue() {
            string s = Console.ReadLine();
            if (String.Equals(s, "y") || String.Equals(s, "n")) {
                return s;
            } else {
                while (!(String.Equals(s, "y") || String.Equals(s, "n"))) {
                    Console.WriteLine("Please enter y or n to continue playing or stop playing.");
                    s = Console.ReadLine();
                }
                return s;

            }
        }

        public string getInputForHS() {
            string s = Console.ReadLine();
            if(String.Equals(s,"s") || String.Equals(s, "h")) {
                return s;
            } else {
                while (!(String.Equals(s, "s") || String.Equals(s, "h"))) {
                    Console.WriteLine("Please enter s or h to hit or stay.");
                    s = Console.ReadLine();
                }
                return s;
                
            }
        }

        

        public void PlayRound() {
            ShowBothHands();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nHit or Stay? type h or s\n");
            string s = getInputForHS();

            if (human.BlackJack()) {
                Console.WriteLine("You got blackjack!");
                human.IncreaseScore();
                return;
            }

            while (!RoundEnd(s)) {
                human.Hit(deck.GetNextCard());
                ShowPlayerCards();
                
                if (human.Busted()) {
                    Console.WriteLine("You busted!");
                    dealer.IncreaseScore();
                    break;
                } else {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\nHit or Stay? type h or s\n");
                    s = getInputForHS();
                }
            }
            if (String.Equals(s, "s")) {
                Stayed();
            }
            Restart();
        }
        
    }
}
