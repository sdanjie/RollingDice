/*
  Danjie Song
  CSC153 C# Programming
  Chapter 5: Console application for Dice Simulator
*/ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDiceSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare variables
            Random randDice = new Random(); // A random object to simulate a dice
            const int SIDE_OF_DICE = 6;     // the number of sides of a dice
            int userDice;                   // the value of user's dice
            int computerDice;               // the value of computer's dice
            int userWins = 0;               // user's winning times
            int computerWins = 0;           // computer's winning times
            int ties = 0;                   // the game tied times
            string answer = "YES";          // to hold the answer of whether the user continue playing

            // Rolling dice simulation
            while (answer == "YES")
            {
                int userDiceSum = 0;        // To hold the sum of user's dice for each roll
                int computerDiceSum = 0;    // To hold the sum of computer's dice for each roll
                Console.WriteLine("\n\t\tDice 1\tDice 2");

                ///// For-loop iterates twice to generate two random values
                ///// Use those two values to represent the values of a pair of dice
                // User's move
                Console.Write("User\t\t"); // Display who is playing
                for (int i = 1; i <= 2; i++)
                {
                    userDice = randDice.Next(SIDE_OF_DICE) + 1;
                    // Display dice value
                    Console.Write(userDice + "\t");
                    // Calculate the sum of dice
                    userDiceSum += userDice;
                }

                // computer's move
                Console.Write("\nComputer\t");  // Display who is playing
                for (int j = 1; j <= 2; j++)
                {
                    computerDice = randDice.Next(SIDE_OF_DICE) + 1;
                    // Display dice value
                    Console.Write(computerDice + "\t");
                    // Calculate the sum of dice
                    computerDiceSum += computerDice;
                }

                // Display the sum of dice value for each roll
                Console.WriteLine("\n-------------------------------");     // Insert a break line
                Console.WriteLine("Your sum: " + userDiceSum + "\tComputer sum: " + computerDiceSum);

                //////////Determine the winner in each turn 
                if (userDiceSum > computerDiceSum)
                {
                    userWins++;
                }   // End if
                else if (userDiceSum < computerDiceSum)
                {
                    computerWins++;
                }   // End else if 1
                else
                {
                    ties++;
                }   // End else

                // Ask user to enter Y or N to continue the game
                Console.WriteLine("Do you want to play again?(Yes/No)"); 
                answer = Console.ReadLine().ToUpper();
                
                // Validate user's answer
                while (answer != "YES" && answer != "NO")
                {
                   Console.WriteLine("Enter Yes or No to continue.");
                   answer = Console.ReadLine().ToUpper();
                } // End while: validate answer 
                
            }   // End while

            // Display the final result
            Console.WriteLine("\n-------------------------------");     // Insert a break line
            Console.WriteLine("You won: " + userWins + "\tComputer won: " + computerWins + "\t\tTies: " + ties);

            // Write the result into a .txt file when user chooses not to play game
            try
            {
                System.IO.StreamWriter outputFile = new System.IO.StreamWriter("game_results.txt");
                outputFile.WriteLine("You won " + userWins);
                outputFile.WriteLine("Computer won " + computerWins);
                outputFile.WriteLine("Game ties in " + ties);
                outputFile.Close();
            }   // End try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   // End catch

            // For the purpose of pausing the console
            Console.ReadLine();
        }   // End main
    }   // End class
}   // End namespace
