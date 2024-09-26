using System;
using System.Windows.Forms;

namespace Assignment2Prj
{
    /// <summary>
    /// Manager class is the center class of the game with attributes: bricks, ball, paddle, windowWidth,
    /// windowHeight, score, gameLevel, lblScore, and lblPowerUp.
    /// The class also has methods: AddBricksToForm, CheckBallPaddleCollision, CheckBallBricksCollision,
    /// UpdateScore, PowerUp, GameOver, and RemoveBricks.
    /// These methods allow the class to manage the game logic.
    /// </summary>
    internal class Manager
    {
        /// Attributes of the Manager class.
        private Bricks bricks; // Bricks object containing all the bricks
        private Ball ball; // Ball object
        private Paddle paddle; // Paddle object
        private int windowWidth, windowHeight; // Dimensions of the game window
        private int score; // Player's score
        private Label lblScore; // Label to display the score
        private Label lblPowerUp; // Label to display power-up information

        /// Gets or sets the score.
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        /// Checks if all bricks are destroyed.
        public bool areAllBricksDestroyed
        {
            get { return bricks.numberOfBricks == 0; }
        }

        /// Constructor for the Manager class.
        /// <param name="bricks">The Bricks object.</param>
        /// <param name="ball">The Ball object.</param>
        /// <param name="paddle">The Paddle object.</param>
        /// <param name="form">The Game form.</param>
        public Manager(Bricks bricks, Ball ball, Paddle paddle, Game form)
        {
            try
            {
                this.bricks = bricks;
                this.ball = ball;
                this.paddle = paddle;
                this.windowWidth = form.Width;
                this.windowHeight = form.Height;
                this.lblScore = form.lblScore;
                this.score = 0;
                this.lblPowerUp = form.lblPowerUp;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during Manager initialization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Adds bricks to the form.
        /// <param name="form">The game form.</param>
        public void AddBricksToForm(Game form)
        {
            try
            {
                foreach (PictureBox brick in bricks.BricksArray)
                {
                    form.Controls.Add(brick);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding bricks to the form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Checks for collision between the ball and the paddle.
        public void CheckBallPaddleCollision()
        {
            try
            {
                if (ball.PicBall.Bounds.IntersectsWith(paddle.PicPaddle.Bounds))
                {
                    ball.VerticalSpeed *= -1; // Reverse the ball's vertical direction
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while checking ball-paddle collision: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Checks for collision between the ball and the bricks.
        /// <param name="form">The game form.</param>
        public void CheckBallBricksCollision(Game form)
        {
            try
            {
                foreach (PictureBox brick in bricks.BricksArray)
                {
                    if (brick.Visible && ball.PicBall.Bounds.IntersectsWith(brick.Bounds))
                    {
                        ball.VerticalSpeed = -ball.VerticalSpeed; // Reverse the ball's vertical direction

                        // Reduce brick durability using row and col from Tag
                        var position = (Tuple<int, int>)brick.Tag;
                        int row = position.Item1;
                        int col = position.Item2;

                        // Change image
                        bricks.SetImage(row, col);

                        if (bricks.GetBrickFirmless(row, col) > 0)
                        {
                            bricks.SetBrickFirmless(row, col);
                            if (bricks.GetBrickFirmless(row, col) == 0)
                            {
                                // Update score and decrement brick count
                                brick.Visible = false;
                                form.Controls.Remove(brick);
                                bricks.numberOfBricks -= 1;
                                score += 10;
                            }
                        }
                        if (Int32.Parse(brick.Text) != 0)
                        {
                            PowerUp(Int32.Parse(brick.Text));
                        }
                        UpdateScore(score);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while checking ball-bricks collision: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Updates the score display.
        /// <param name="score">The new score to display.</param>
        public void UpdateScore(int score)
        {
            try
            {
                lblScore.Text = "Score: " + score;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the score: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Applies a power-up based on the power-up number.
        /// <param name="powerUpNumber">The random number generated when creating bricks (range 1-5).</param>
        private void PowerUp(int powerUpNumber)
        {
            try
            {
                switch (powerUpNumber)
                {
                    case 1:
                        // Double the paddle size
                        paddle.PicPaddle.Width *= 2;
                        lblPowerUp.Text = "Power Up: Longer Paddle!!! + Extra 10!!!";
                        score += 10;
                        break;
                    case 2:
                        // Increase paddle speed
                        paddle.PaddleSpeed += 15;
                        lblPowerUp.Text = "Power Up: Faster Paddle Speed!!! + Extra 10!!!";
                        score += 10;
                        break;
                    case 3:
                        // Reset paddle size to original
                        paddle.PicPaddle.Width = 110;
                        // Decrease paddle speed
                        paddle.PaddleSpeed = 15;
                        lblPowerUp.Text = "";
                        break;
                    case 4:
                        // Reset paddle size to original
                        paddle.PicPaddle.Width = 110;
                        // Decrease paddle speed
                        paddle.PaddleSpeed = 15;
                        lblPowerUp.Text = "";
                        break;
                    case 5:
                        // Reset paddle size to original
                        paddle.PicPaddle.Width = 110;
                        // Decrease paddle speed
                        paddle.PaddleSpeed = 15;
                        lblPowerUp.Text = "";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while applying power-up: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Determines if the game is over.
        /// <returns>True if the game is over, false otherwise.</returns>
        public bool GameOver()
        {
            try
            {
                // Check if the ball is out of the window
                if (ball.PicBall.Top >= windowHeight)
                {
                    return true;
                }
                // Check if all bricks are gone
                if (bricks.numberOfBricks == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while checking if the game is over: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// Method that removes bricks from the game form.
        /// <param name="form">The game form.</param>
        public void RemoveBricks(Game form)
        {
            try
            {
                foreach (PictureBox x in bricks.BricksArray)
                {
                    x.Visible = false;
                    form.Controls.Remove(x);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while removing bricks from the form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
