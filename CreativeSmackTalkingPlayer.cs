using System;
using System.Collections.Generic;

namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        //random code do it in the play method
        //beware of indexes in List
        //create list of taunts
        List<string> listOfTaunts = new List<string>()
        {
            "You call that a roll?",
            "I fart in your general direction",
            "You call yourself a dice roller?",
            "Amateur!",
            "Your mother was a hamster and your father smelt of elderberries?"
        };

        public override void Play(Player other)
        {
            // Call roll for "this" object and for the "other" object
            int randomIndex = new Random().Next(0, listOfTaunts.Count);
            Console.WriteLine(listOfTaunts[randomIndex]);
            int myRoll = Roll();
            int otherRoll = other.Roll();

            Console.WriteLine($"{Name} rolls a {myRoll}");
            Console.WriteLine($"{other.Name} rolls a {otherRoll}");
            if (myRoll > otherRoll)
            {
                Console.WriteLine($"{Name} Wins!");
            }
            else if (myRoll < otherRoll)
            {
                Console.WriteLine($"{other.Name} Wins!");
            }
            else
            {
                // if the rolls are equal it's a tie
                Console.WriteLine("It's a tie");
            }
        }

    }
}