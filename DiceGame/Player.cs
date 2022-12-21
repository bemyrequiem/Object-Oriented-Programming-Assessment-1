using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    // Player object
    internal class Player
    {
        // Initialising variables
        public string name { get; set; }
        public int score { get; set; }

        // Method to update the player's score
        private void updateScore(int i)
        {
            this.score += i;
        }

        // Method to print the player's rolls to the console
        private void printRolls(List<int> rolls)
        {
            string str = $"{this.name}, your rolls are: ";

            foreach (int roll in rolls)
            {
                str += $"{roll} ";
            }

            Console.WriteLine(str);
        }

        // Method to reroll the remaining dice after the player
        // rolls a two of a kind
        private void Reroll(Die die, int mode)
        {
            // Initialising new rolls list
            List<int> rolls = new List<int>();

            // Roll twice
            for (int i = 0; i < 2; i++)
            {
                rolls.Add(die.Roll());
            }

            // Check to see if one of the rolls is the same as the
            // existing two of a kind, if it is then keep rolling and
            // if not then give the player zero
            if (rolls.Contains(mode))
            {
                rolls.Add(die.Roll());

                // Adding the existing two of a kind to the front of the list
                rolls.Insert(0, mode);
                rolls.Insert(0, mode);

                // Print the rolls to the console and calculate the score
                this.printRolls(rolls);
                this.calculateScore(die, rolls);
            }
            else
            {
                // Adding the existing two of a kind to the front of the list
                rolls.Insert(0, mode);
                rolls.Insert(0, mode);

                // Print the rolls to the console and give no score
                this.printRolls(rolls);

                Console.WriteLine("Unfortunately, you scored zero.");
                return;
            }
        }

        // Method to calculate the score from the rolls
        private void calculateScore(Die die, List<int> rolls)
        {
            // Initialising variables by performing methods that will
            // give the mode and the amount of times it appears
            var groups = rolls.GroupBy(a => a);
            int maxCount = groups.Max(b => b.Count());
            int mode = groups.First(g => g.Count() == maxCount).Key;

            // Switch case to give a score based on the amount of
            // times the modal roll appears
            switch (maxCount)
            {
                case 5:
                    Console.WriteLine("Congratulations! You got five of a kind. (+12)");
                    this.updateScore(12);
                    break;

                case 4:
                    Console.WriteLine("Good job! You got four of a kind. (+6)");
                    this.updateScore(6);
                    break;

                case 3:
                    Console.WriteLine("Nice, you got three of a kind. (+3)");
                    this.updateScore(3);
                    break;

                // If there are two of a kind, give the player the option
                // to reroll the remaining dice
                case 2:
                    string option;

                    // Ask the user yes or no question with error handling
                    while (true)
                    {
                        Console.WriteLine("You only got two of a kind (+1), would" +
                            " you like to reroll your remaining dice? If neither of" +
                            " your first two rolls match you will score zero. (y/n)");
                        option = Console.ReadLine();

                        if (option.ToLower() == "y")
                        {
                            this.Reroll(die, mode);
                            break;
                        }
                        else if (option.ToLower() == "n")
                        {
                            this.updateScore(1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That is an invalid answer.");
                        }
                    }

                    break;

                default:
                    Console.WriteLine("Unfortunately, you scored zero.");
                    break;
            }
        }

        // Method to execute the player's turn
        public void Turn(Die die)
        {
            // Initialising a list to hold the 5 rolls
            List<int> rolls = new List<int>();

            // Perform 5 rolls and add them to the rolls list
            for (int i = 0; i < 5; i++)
            {
                rolls.Add(die.Roll());
            }

            // Print the rolls to the console and calculate the score
            this.printRolls(rolls);
            this.calculateScore(die, rolls);
        }

        // Constructor
        public Player(string name)
        {
            this.name = name;
            this.score = 0;
        }
    }
}
