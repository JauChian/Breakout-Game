using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace Assignment2PrjTests
{
    [TestClass]
    public class PaddleTest
    {
        /// <summary>
        /// Test the Paddle move method
        /// The picPaddle moves to the expected place when moving right
        /// </summary>
        [TestMethod]
        public void PaddleMoveRight()
        {
            // Arrange
            int windowWidth = 1238;
            int paddleSpeed = 10;
            PictureBox picPaddle = new PictureBox
            {
                Width = 165,
                Height = 30,
                Top = 515,
                Left = 737
            };

            int expectedLeftPosition = picPaddle.Left + paddleSpeed;

            // Act
            if (picPaddle.Left + picPaddle.Width + paddleSpeed <= windowWidth)
            {
                picPaddle.Left += paddleSpeed;
            }
            else
            {
                picPaddle.Left = windowWidth - picPaddle.Width;
            }

            if (picPaddle.Left == expectedLeftPosition)
            {
                Console.WriteLine($"Paddle moved correctly to the right: {picPaddle.Left}");
            }
            else
            {
                Console.WriteLine($"Paddle move out of boundary, adjusted to: {picPaddle.Left}");
            }
        }

        /// <summary>
        /// Test the Paddle move method
        /// The picPaddle moves to the expected place when moving left
        /// </summary>
        [TestMethod]
        public void PaddleMoveLeft()
        {
            // Arrange
            int paddleSpeed = 10;
            PictureBox picPaddle = new PictureBox
            {
                Width = 165,
                Height = 30,
                Top = 515,
                Left = 737
            };

            int expectedLeftPosition = picPaddle.Left - paddleSpeed;

            // Act
            if (picPaddle.Left - paddleSpeed >= 0)
            {
                picPaddle.Left -= paddleSpeed;
            }
            else
            {
                picPaddle.Left = 0;
            }

            if (picPaddle.Left == expectedLeftPosition)
            {
                Console.WriteLine($"Paddle moved correctly to the left: {picPaddle.Left}");
            }
            else
            {
                Console.WriteLine($"Paddle move out of boundary, adjusted to: {picPaddle.Left}");
            }
        }
    }
}
