using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment2PrjTest
{
    [TestClass]
    public class ManagerTest
    {
        /// <summary>
        /// Test the powerUp method to set picPaddle width correctly 
        /// </summary>
        [TestMethod]
        public void PowerUpForWidth()
        {
            // Arrange
            PictureBox picPaddle = new PictureBox
            {
                Width = 110,
                Height = 30
            };
            Random rnd = new Random();
            Label lblPowerUp = new Label();
            int powerUpNumber = rnd.Next(1, 6);
            int paddleSpeed = 15;
            int score = 0;
            switch (powerUpNumber)
            {
                case 1:
                    // Decrease paddle speed
                    paddleSpeed = 15;
                    // Double the paddle size
                    picPaddle.Width *= 2;
                    //when hit PowerUp give additional 10 points
                    lblPowerUp.Text = "Power Up: Longer Paddle!!! + Extra 10!!!";
                    score += 10;
                    break;
                case 2:
                    // Reset paddle size to original
                    picPaddle.Width = 110;
                    // Increase paddle speed
                    paddleSpeed += 15;
                    //when hit PowerUp give additional 10 points
                    lblPowerUp.Text = "Power Up: Faster Paddle Speed!!! + Extra 10!!!";
                    score += 10;
                    break;
                case 3:
                    // Reset paddle size to original
                    picPaddle.Width = 110;
                    // Decrease paddle speed
                    paddleSpeed = 15;
                    lblPowerUp.Text = "";
                    break;
                case 4:
                    // Reset paddle size to original
                    picPaddle.Width = 110;
                    // Decrease paddle speed
                    paddleSpeed = 15;
                    lblPowerUp.Text = "";
                    break;
                case 5:
                    // Reset paddle size to original
                    picPaddle.Width = 110;
                    // Decrease paddle speed
                    paddleSpeed = 15;
                    lblPowerUp.Text = "";
                    break;
            }

            // Act
            // Output final states     
            Console.WriteLine($"Switch case: {powerUpNumber}");
            Console.WriteLine($"picPaddle width is : {picPaddle.Width}, paddleSpeed is : {paddleSpeed}, lblPowerUp test is set: {lblPowerUp.Text}");

        }

        /// <summary>
        /// Test GameOver method to set bool attributes correctly, its a random test might need to rerun it
        /// </summary>
        [TestMethod]
        public void GameOver()
        {
            // Arrange
            bool isGameOver;
            bool isBricksAllGone;
            Random rnd = new Random();
            PictureBox picBall = new PictureBox
            {
                Top = rnd.Next(0, 50)
            };
            int windowHeight = 20;

            // Act
            if (picBall.Top >= windowHeight)
            {
                isGameOver = true;
                Console.WriteLine("Ball is out of window height, game over.");
            }
            else
            {
                isGameOver = false;
                Console.WriteLine("Ball is within window height.");
            }

            int numberOfBricks = rnd.Next(0, 5);
            if (numberOfBricks == 0)
            {
                isBricksAllGone = true;
                isGameOver = true;
                Console.WriteLine("All bricks are gone, game over.");
            }
            else
            {
                isBricksAllGone = false;
                isGameOver = false;
                Console.WriteLine("There are still bricks remaining.");
            }

            // Output final states
            Console.WriteLine($"isBricksAllGone: {isBricksAllGone}, isGameOver: {isGameOver}");
        }
    }
}
