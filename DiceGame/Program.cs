using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialising variables
            bool playing;
            string option;

            // Do while loop to keep playing the game multiple times
            // until the user decides to quit
            do
            {
                // Loop to ask if the player wants to play the game with error handling
                while (true)
                {
                    Console.WriteLine("Welcome to Alfie Atkinson's Dice game," +
                        " would you like to play? (y/n)");
                    option = Console.ReadLine();

                    if (option.ToLower() == "y")
                    {
                        // Initialising variables
                        Die die;
                        playing = true;

                        // Ask the user how many sides the dice should have
                        // with error handling to prevent strings or numbers
                        // lower than zero
                        while (true)
                        {
                            Console.WriteLine("How many sides would you like" +
                                " on your dice?");
                            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                            {
                                die = new Die(n);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You must enter an integer" +
                                    " above zero.");
                            }
                        }

                        // Ask the user how many players are playing and assign
                        // a game type to the game variable with error handling
                        // and then execute the Play() method
                        while (true)
                        {
                            Console.WriteLine("How many players would you like? (2 or 3)");
                            option = Console.ReadLine();

                            if (option == "2")
                            {
                                var game = new TwoPlayerGame(die);
                                game.Play();
                                break;
                            }
                            else if (option == "3")
                            {
                                var game = new ThreePlayerGame(die);
                                game.Play();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("That is an invalid input.");
                            }
                        }
                        break;
                    }
                    else if (option.ToLower() == "n")
                    {
                        playing = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That input is invalid, please try again.\n");
                    }
                }
            } while (playing);
        }
    }
}
