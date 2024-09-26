using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Assignment2Prj;

namespace Assignment2PrjTests
{
    [TestClass]
    public class BallTests
    {
        /// <summary>
        ///  The test method that test ball moves correctly
        /// </summary>
        [TestMethod]
        public void BallMove()
        {
            PictureBox picBall = new PictureBox();
            picBall.Width = 30;
            picBall.Height = 30;
            picBall.Top = 583;
            picBall.Left = 685;
            int horizontalSpeed = 5;
            int verticalSpeed = 5;
            int windowWidth = 1238;
            int menuHeight = 30;
            // Move the ball by updating its position
            picBall.Left += horizontalSpeed;
            picBall.Top += verticalSpeed;

            // Check for collision with the left or right walls
            if ((picBall.Left >= windowWidth - picBall.Width) || (picBall.Left <= 0))
            {
                horizontalSpeed *= -1; // Reverse horizontal direction
            }
            // Check for collision with the top wall
            if (picBall.Top <= 0 + menuHeight)
            {
                verticalSpeed *= -1; // Reverse vertical direction
            }

        }
    }
}
