using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment2Prj;

namespace Assignment2PrjTests
{
    [TestClass]
    public class GameTest
    {
        /// <summary>
        /// Test the setGameLevel is correct
        /// Set gameLevel randomly 
        /// </summary>
        [TestMethod]
        public void SetGameLevel()
        {
            // Arrange
            Random rnd = new Random();
            int gameLevel = rnd.Next(1, 5); // Generate random game level between 1 and 4
            int verticalSpeed = 0;
            int horizontalSpeed = 0;
            int bricksRows = 0;
            int bricksCols = 0;
            int paddleSpeed = 0;

            // Ensure gameLevel is within the valid range
            if (gameLevel <= 0)
            {
                gameLevel = 1; // Default to level 1 if invalid level is provided
            }
            else if (gameLevel > 3)
            {
                gameLevel = 3; // Cap level to 3 if it's greater than 3
            }

            // Set parameters based on game level
            switch (gameLevel)
            {
                case 1:
                    // Adjust these numbers for level 1
                    verticalSpeed = 5;
                    horizontalSpeed = 5;
                    bricksRows = 3;
                    bricksCols = 6;
                    paddleSpeed = 15;
                    break;
                case 2:
                    // Adjust these numbers for level 2
                    verticalSpeed = 6;
                    horizontalSpeed = 6;
                    bricksRows = 4;
                    bricksCols = 7;
                    paddleSpeed = 15;
                    break;
                case 3:
                    // Adjust these numbers for level 3
                    verticalSpeed = 7;
                    horizontalSpeed = 7;
                    bricksRows = 5;
                    bricksCols = 8;
                    paddleSpeed = 10;
                    break;
            }

            // Output results using Console.WriteLine
            Console.WriteLine($"Game Level: {gameLevel}");
            Console.WriteLine($"Vertical Speed: {verticalSpeed}");
            Console.WriteLine($"Horizontal Speed: {horizontalSpeed}");
            Console.WriteLine($"Bricks Rows: {bricksRows}");
            Console.WriteLine($"Bricks Columns: {bricksCols}");
            Console.WriteLine($"Paddle Speed: {paddleSpeed}");
        }
    }
}
