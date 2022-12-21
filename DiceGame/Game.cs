using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{

    // Parent game class
    internal abstract class Game
    {
        // Initialising variables
        private int goal = 20;
        protected int n_of_players;
        protected bool playing = false;
        public List<Player> player_list = new List<Player>();
        public Die die { get; set; }

        // Method to add players to the player_list based on the number of players
        public void addPlayers()
        {
            for (int i = 0; i < n_of_players; i++)
            {
                Console.WriteLine($"What is the name of player {i + 1}?");
                this.player_list.Add(new Player(Console.ReadLine()));
            }
        }

        // Method to check if the game has been won
        public bool checkWin()
        {
            foreach (Player player in this.player_list)
            {
                if (player.score >= this.goal)
                {
                    Console.WriteLine($"{player.name} wins!");
                    return true;
                }
            }
            return false;
        }

        // Method to write the scores to the console
        public void printScores()
        {
            string scores = "";

            foreach (Player player in this.player_list)
            {
                scores += $"{player.name}: {player.score}    ";
            }

            Console.WriteLine(scores);
        }

        // Method to play the game which will be changed in child objects
        public void Play()
        {
            // Do nothing
        }

        // Constructors
        public Game(Die die)
        {
            this.die = die;
        }
    }

    // Child object of Game for a two player game
    internal class TwoPlayerGame : Game
    {
        // Polymorphed Play method
        public void Play()
        {
            // Initialising variables
            int turn = 0;
            this.playing = true;

            // Run method to add players to the player list
            this.addPlayers();

            // Main game loop
            while (this.playing)
            {
                Console.WriteLine("\nPress enter to roll.");
                Console.ReadLine();

                // Switch case to see whos turn it is and execute the
                // player's turn function
                switch (turn)
                {
                    case 0:
                        player_list[0].Turn(die);
                        turn++;
                        break;
                    case 1:
                        player_list[1].Turn(die);
                        turn = 0;
                        break;
                }

                // Print the scores to the console
                this.printScores();

                // Check for win
                if (this.checkWin())
                {
                    playing = false;
                }
            }
        }

        // Constructor
        public TwoPlayerGame(Die die) : base(die)
        {
            this.die = die;
            this.n_of_players = 2;
        }
    }

    // Child object of Game for a three player game
    internal class ThreePlayerGame : Game
    {
        // Polymorphed Play method
        public void Play()
        {
            // Initialising variables
            int turn = 0;
            this.playing = true;

            // Run method to add players to the player list
            this.addPlayers();

            // Main game loop
            while (this.playing)
            {
                Console.WriteLine("\nPress enter to roll.");
                Console.ReadLine();

                // Switch case to see whos turn it is and execute the
                // player's turn function
                switch (turn)
                {
                    case 0:
                        player_list[0].Turn(die);
                        turn++;
                        break;
                    case 1:
                        player_list[1].Turn(die);
                        turn++;
                        break;
                    case 2:
                        player_list[2].Turn(die);
                        turn = 0;
                        break;
                }

                // Print the scores to theD console
                this.printScores();

                // Check for win
                if (this.checkWin())
                {
                    playing = false;
                }
            }
        }

        // Constructor
        public ThreePlayerGame(Die die) : base(die)
        {
            this.die = die;
            this.n_of_players = 3;
        }
    }
}
