using System;
using System.Windows.Forms;

namespace Assignment2Prj
{
    /// <summary>
    /// The Ball class includes attrubutes: picBall and verticalSpeed, horizontalSpeed,
    /// and also includes BallMove method that defines picBall moving logic
    /// </summary>
    class Ball
    {
        // Attributes
        private PictureBox picBall;
        private int verticalSpeed, horizontalSpeed;

        // Property for PictureBox
        public PictureBox PicBall
        {
            get { return picBall; }
            set { picBall = value; }
        }

        // Property for vertical speed
        public int VerticalSpeed
        {
            get { return verticalSpeed; }
            set { verticalSpeed = value; }
        }

        // Property for horizontal speed
        public int HorizontalSpeed
        {
            get { return horizontalSpeed; }
            set { horizontalSpeed = value; }
        }

        // Constructor for Ball class
        public Ball(PictureBox picBall, int verticalSpeed, int horizontalSpeed)
        {
            try
            {
                this.PicBall = picBall ?? throw new ArgumentNullException(nameof(picBall));
                this.verticalSpeed = verticalSpeed;
                this.horizontalSpeed = horizontalSpeed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during Ball initialization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Method to move the ball.
        /// <param name="windowWidth">The width of the window.</param>
        /// <param name="windowHeight">The height of the window.</param>
        /// <param name="menuHeight">The height of the stripMenu.</param>
        public void BallMove(int windowWidth, int windowHeight, int menuHeight)
        {
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while moving the ball: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
