using System;
using System.Collections.Generic;

namespace RpsGame_NoDb
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            List<Round> rounds = new List<Round>();
            List<Match> matches = new List<Match>();

            // generate the glorious computer overlord
            Player p1 = new Player()
            {
                Fname = "Max",
                Lname = "Headroom",
            };

            players.Add(p1);

            Console.WriteLine("This is The Official Batch Rock-Paper-Scissors Game");

            // log in or create a new player.
            // unique fName and lName means create a new player,
            // otherwise grab the existing player

            string[] names;
            do
            {

                Console.WriteLine("Please enter your name.\nIf you enter a unique name I will create a new player.");
                string userName = Console.ReadLine();
                names = userName.Split(' ');
            } while (names[0] == "");

            // Creates a player object for login
            Player p2 = new Player();
            if (names.Length == 1)
            {
                p2.Fname = names[0];
            }
            else
            {
                p2.Fname = names[0];
                p2.Lname = names[1];
            }


            players.Add(p2);

            Match match = new Match();
            match.Player1 = p1;
            match.Player2 = p2;

            Round round = new Round();

            // declare these two variables to be used in the do/while loop
            Choice userChoice;
            bool userResponseParsed;
            //int roundCount;

            do
            {
                Console.WriteLine($"Welcome {p2.Fname}. Please choose Rock, Paper, or Scissors by typing 1, 2, or 3 and hitting enter.");
                Console.WriteLine("\t1. Rock \n\t2. Paper \n\t3. Scissors");

                string userResponse = Console.ReadLine();   // read the users unput

                userResponseParsed = Choice.TryParse(userResponse, out userChoice);    // parse the users input to am int

                if (userResponseParsed == false || ((int)userChoice > 3 || (int)userChoice < 1))  // give a message if the users unput was invalid
                {
                    Console.WriteLine("Your response is invalid.");
                }

            } while (userResponseParsed == false || (int)userChoice > 3 || (int)userChoice < 1);  // state conditions for if we will repeat the loop

            Console.WriteLine("Starting the game...");

            Random randomNumber = new Random(); // create a randon number object
            Choice computerChoice = (Choice)randomNumber.Next(1, 4);   // get a random number 1, 2, or 3.

            round.Player1Choice = computerChoice;
            round.Player2Choice = userChoice;

            Console.WriteLine($"The computer choice is => {computerChoice}");

            // compare the numbers to see who won.
            if (userChoice == computerChoice)   // if the players tied
            {
                rounds.Add(round);
                match.Rounds.Add(round);
            }
            // if the user won
            else if (((int)userChoice == 2 && (int)computerChoice == 1) ||
                ((int)userChoice == 3 && (int)computerChoice == 2) ||
                ((int)userChoice == 1 && (int)computerChoice == 3))
            {
                round.WinningPlayer = p2;
                rounds.Add(round);
                match.Rounds.Add(round);
                match.RoundWinner(p2);
            }
            // if the computer won
            else
            {
                round.WinningPlayer = p1;
                rounds.Add(round);
                match.Rounds.Add(round);
                match.RoundWinner(p1);
            }
            Console.WriteLine($"\n\tROUND {rounds.Count}-\n\n\tFIGHT!\n\n P1 chose to fight with {round.Player1Choice}\n P2 chose to fight with {round.Player2Choice}\n The winner of this round is {round.WinningPlayer.Fname}");
        }
    }
}