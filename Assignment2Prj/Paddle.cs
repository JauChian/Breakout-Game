using System;
using System.Windows.Forms;

namespace Assignment2Prj
{
    /// <summary>
    /// Paddle class includes attrubutes: picPaddle and paddle Speed 
    /// and also includes methods: PaddleMoveLeft and PaddleMoveRight
    /// The basic paddle logic is applied in the class
    /// </summary>
    class Paddle
    {
        private PictureBox picPaddle;
        private int paddleSpeed;

        /// Gets the PictureBox representing the paddle.
        public PictureBox PicPaddle
        {
            get { return picPaddle; }
            private set { picPaddle = value; }
        }

        public int PaddleSpeed
        {
            get { return paddleSpeed; }
            set { paddleSpeed = value; }
        }

        /// Initializes a new instance of the Paddle class with the specified PictureBox and speed.
        public Paddle(PictureBox picPaddle, int paddleSpeed)
        {
            try
            {
                this.picPaddle = picPaddle ?? throw new ArgumentNullException(nameof(picPaddle));
                this.paddleSpeed = paddleSpeed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during Paddle initialization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Moves the paddle to the right within the bounds of the window.
        /// <param name="windowWidth">The width of the window.</param>
        public void PaddleMoveRight(int windowWidth)
        {
            try
            {
                // Ensure the paddle does not move out of the right boundary
                if (picPaddle.Left + picPaddle.Width + paddleSpeed <= windowWidth)
                {
                    picPaddle.Left += paddleSpeed;
                }
                else
                {
                    picPaddle.Left = windowWidth - picPaddle.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while moving the paddle to the right: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Moves the paddle to the left within the bounds of the window.
        public void PaddleMoveLeft()
        {
            try
            {
                // Ensure the paddle does not move out of the left boundary
                if (picPaddle.Left - paddleSpeed >= 0)
                {
                    picPaddle.Left -= paddleSpeed;
                }
                else
                {
                    picPaddle.Left = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while moving the paddle to the left: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
