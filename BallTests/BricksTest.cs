using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Assignment2Prj;
using System.Drawing;

namespace Assignment2PrjTests
{
    [TestClass]
    public class BricksTests
    {
        [TestMethod]
        public void TestCreateBricks()
        {
            int rows = 5;
            int cols = 5;
            int windowWidth = 800;
            int brickWidth = 100;
            int brickHeight = 40;
            int _numberOfBricks = 0;
            int top = 50;
            int gapHeight = 10;
            int gapWidth = (windowWidth - (cols * brickWidth)) / (cols + 1);
            Random rnd = new Random();
            PictureBox[,] bricks = new PictureBox[rows, cols];

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    // Create a new PictureBox for the brick
                    bricks[x, y] = new PictureBox();
                    bricks[x, y].Size = new Size(brickWidth, brickHeight);

                    // Set the position of the brick
                    bricks[x, y].Left = gapWidth + brickWidth * y + gapWidth * y;
                    bricks[x, y].Top = top + brickHeight * x + gapHeight * x;

                    // bricks[x, y].BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                    // Generate a random number for the brick and use it for PowerUp
                    int randomNumber = rnd.Next(1, 6);
                    bricks[x, y].Text = randomNumber.ToString();

                    // Set a tag for the brick
                    bricks[x, y].Tag = "bricks";

                    // Adding total bricks number 
                    _numberOfBricks++;
                }
            }

            // Check bricks array
            if (bricks == null)
            {
                Console.WriteLine("Bricks array should not be null.");
                return;
            }
            if (bricks.GetLength(0) != rows)
            {
                Console.WriteLine($"Rows count mismatch: Expected {rows}, but got {bricks.GetLength(0)}.");
                return;
            }
            if (bricks.GetLength(1) != cols)
            {
                Console.WriteLine($"Columns count mismatch: Expected {cols}, but got {bricks.GetLength(1)}.");
                return;
            }

            // Check every brick is in correct form
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (bricks[x, y] == null)
                    {
                        Console.WriteLine($"Brick at position ({x}, {y}) should not be null.");
                        return;
                    }
                    if (bricks[x, y].Size != new Size(brickWidth, brickHeight))
                    {
                        Console.WriteLine($"Size mismatch at position ({x}, {y}): Expected {new Size(brickWidth, brickHeight)}, but got {bricks[x, y].Size}.");
                        return;
                    }
                    if ((string)bricks[x, y].Tag != "bricks")
                    {
                        Console.WriteLine($"Tag mismatch at position ({x}, {y}): Expected 'bricks', but got {bricks[x, y].Tag}.");
                        return;
                    }
                }
            }

            // Check the number of total bricks matches rows*cols
            if (_numberOfBricks != rows * cols)
            {
                Console.WriteLine($"Total number of bricks mismatch: Expected {rows * cols}, but got {_numberOfBricks}.");
                return;
            }

            Console.WriteLine("All checks passed successfully.");
        }
    }
}
