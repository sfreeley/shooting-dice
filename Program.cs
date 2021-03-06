﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            player1.Name = "Bob";

            Player player2 = new Player();
            player2.Name = "Sue";

            player2.Play(player1);

            Console.WriteLine("-------------------");

            Player player3 = new Player();
            player3.Name = "Wilma";

            player3.Play(player2);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            large.Play(player3);

            Console.WriteLine("-------------------");

            Player smackTalker = new SmackTalkingPlayer();
            smackTalker.Name = "Punk";
            smackTalker.Play(large);

            Console.WriteLine("-------------------");

            Player oneHigher = new OneHigherPlayer();
            oneHigher.Name = "OneUpper";
            oneHigher.Play(smackTalker);

            Console.WriteLine("-------------------");

            Player hooman = new HumanPlayer();
            hooman.Name = "Earthling";
            hooman.Play(oneHigher);

            Console.WriteLine("-------------------");

            Player creativeSmackTalker = new CreativeSmackTalkingPlayer();
            creativeSmackTalker.Name = "ArtisticPunk";
            creativeSmackTalker.Play(hooman);

            Console.WriteLine("-------------------");

            Player todd = new SoreLoserPlayer();
            todd.Name = "Todd";
            todd.Play(creativeSmackTalker);

            Console.WriteLine("-------------------");

            Player smug = new UpperHalfPlayer();
            smug.Name = "McGee";
            smug.Play(todd);

            Console.WriteLine("-------------------");

            Player worst = new SoreLoserUpperHalfPlayer();
            worst.Name = "The Worst";
            worst.Play(player1);

            List<Player> players = new List<Player>()
            {
                player1,
                player2,
                player3,
                large,
                smackTalker,
                oneHigher,
                hooman,
                creativeSmackTalker,
                todd,
                smug,
                worst

            };

            PlayMany(players);
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            // if number of players is not divisible by 2 (ie not even), subtract 1 to make it even
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play one another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                player1.Play(player2);
            }
        }
    }
}