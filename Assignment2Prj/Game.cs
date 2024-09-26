using System;
using System.Media;
using System.Windows.Forms;

namespace Assignment2Prj
{
    public partial class Game : Form
    {
        // Game elements
        private Bricks bricks;
        private Ball ball;
        private Paddle paddle;
        private Manager manager;

        // Game settings
        private int verticalSpeed;
        private int horizontalSpeed;
        private int bricksRows;
        private int bricksCols;
        private int paddleSpeed;

        // Game state
        private int gameLevel;
        private bool gameOver;

        // Game Music
        private SoundPlayer backgroundMusic;

        /// Constructor for the Game form.
        /// <param name="gameLevel">Initial game level.</param>
        public Game(int gameLevel)
        {
            try
            {
                this.gameLevel = gameLevel;
                SetGameLevel(gameLevel);
                InitializeComponent();

                //InitializeMusic
                backgroundMusic = new SoundPlayer(Properties.Resources.GameBackGround);
                backgroundMusic.Play();

                // Create game objects
                this.ball = new Ball(picBall, verticalSpeed, horizontalSpeed);
                this.paddle = new Paddle(picPaddle, paddleSpeed);
                this.bricks = new Bricks(bricksRows, bricksCols, this.Width, this.Height,this.gameLevel);
                this.manager = new Manager(bricks, ball, paddle, this);
                manager.AddBricksToForm(this);
                this.lblGameLevel.Text= "Game Level : "+gameLevel;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during game initialization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for form load event
        private void Game_Load(object sender, EventArgs e)
        {

        }

        // Event handler for the game timer tick event
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!gameOver)
                {
                    // Move the ball and check for collisions
                    ball.BallMove(this.Width, this.Height, menuStrip1.Height);
                    manager.CheckBallBricksCollision(this);
                    manager.CheckBallPaddleCollision();

                    // Check if the game is over
                    gameOver = manager.GameOver();
                }
                else
                {
                    // Stop the game and show the end game screen
                    timer.Stop();
                    backgroundMusic.Stop();
                    this.Hide();
                    EndGame endGame = new EndGame(manager.Score, manager.areAllBricksDestroyed, gameLevel);
                    endGame.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during the game loop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer.Stop();
                backgroundMusic.Stop();
            }
        }

        // Event handler for key down events
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Move paddle right or left based on arrow key press
                if (e.KeyCode == Keys.Right)
                {
                    paddle.PaddleMoveRight(this.ClientSize.Width);
                }
                else if (e.KeyCode == Keys.Left)
                {
                    paddle.PaddleMoveLeft();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing key press: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Sets the game level and corresponding parameters.
        /// <param name="gameLevel">The game level to set.</param>
        public void SetGameLevel(int gameLevel)
        {
            try
            {
                this.gameOver = false;

                // Ensure gameLevel is within the valid range
                if (gameLevel <= 0)
                {
                    gameLevel = 1; // Default to level 1 if invalid level is provided
                }
                else if (gameLevel > 4)
                {
                    gameLevel = 4; // Cap level to 4 if it's greater than 4
                }

                this.gameLevel = gameLevel;

                // Set parameters based on game level
                switch (gameLevel)
                {
                    case 1:
                        // Adjust these numbers for level 1
                        this.verticalSpeed = 5;
                        this.horizontalSpeed = 5;
                        this.bricksRows = 3;
                        this.bricksCols = 6;
                        this.paddleSpeed = 15;
                        break;
                    case 2:
                        // Adjust these numbers for level 2
                        this.verticalSpeed = 6;
                        this.horizontalSpeed = 6;
                        this.bricksRows = 4;
                        this.bricksCols = 7;
                        this.paddleSpeed = 15;
                        break;
                    case 3:
                        // Adjust these numbers for level 3
                        this.verticalSpeed = 7;
                        this.horizontalSpeed = 7;
                        this.bricksRows = 4;
                        this.bricksCols = 8;
                        this.paddleSpeed = 15;
                        break;
                    case 4:
                        // Adjust these numbers for level 4
                        this.verticalSpeed = 7;
                        this.horizontalSpeed = 7;
                        this.bricksRows = 5;
                        this.bricksCols = 8;
                        this.paddleSpeed = 15;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while setting the game level: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for click event
        // This method pause the game and stop the music
        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (timer.Enabled == false)
                {
                    timer.Enabled = true;
                    backgroundMusic.Play();
                }
                else
                {
                    timer.Enabled = false;
                    backgroundMusic.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while pausing/resuming the game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for click event
        // This method closes the game
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exiting the game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for click event
        // This method restart the game
        private void nextLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Stop any ongoing game activity
                timer.Stop();
                backgroundMusic.Stop();

                // Remove old bricks from form and set numberOfBricks = 0
                manager.RemoveBricks(this);
                bricks.numberOfBricks = 0;

                ResetGame(gameLevel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while advancing to the next level: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method that ResetGame
        private void ResetGame(int gameLevel)
        {
            try
            {
                // Reset score and update to lblScore
                manager.UpdateScore(0);

                // Set game level parameters
                SetGameLevel(gameLevel);

                // Reset game elements
                this.ball = new Ball(picBall, verticalSpeed, horizontalSpeed);
                this.paddle = new Paddle(picPaddle, paddleSpeed);
                this.bricks = new Bricks(bricksRows, bricksCols, this.Width, this.Height, this.gameLevel);
                this.manager = new Manager(bricks, ball, paddle, this);

                // Add new bricks to form
                manager.AddBricksToForm(this);

                //reset other attributes
                picPaddle.Width = 110;
                lblPowerUp.Text = "";
                lblGameLevel.Text = "Game Level: " + gameLevel;
                lblScore.Text = "Score: 0";
                picBall.Top = this.Height/2;
                picBall.Left = this.Width / 2;
                picPaddle.Left = this.Width/2;

                // Reset game over state 
                this.gameOver = false;


                // Start the game timer and background music
                timer.Start();
                backgroundMusic.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while resetting the game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
