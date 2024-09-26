using System;
using System.Media;
using System.Windows.Forms;

namespace Assignment2Prj
{
    /// <summary>
    /// EndGame form is displaied after user finish the game and provides inofrmation 
    /// about the score and whether lose or win the game. 
    /// The form also provide 3 buttons that allows the user to be able to either "Try again", "Next Level" or "Exit"
    /// </summary>
    public partial class EndGame : Form
    {
        int gameLevel;
        // Game Music
        private SoundPlayer WinningMusic;
        private SoundPlayer LoseMusic;

        // Constructor for the EndGame form
        // Parameters:
        // - Score: The final score achieved by the player
        // - areBricksAllGone: The result of the game (true if the player won, false if lost)
        // - gameLevel: The current level of the game
        public EndGame(int Score, bool areBricksAllGone, int gameLevel)
        {
            try
            {
                this.gameLevel = gameLevel; // Set the current game level
                InitializeComponent(); // Initialize form components

                // Display the player's score
                lblResult.Text = "Your Score : " + Score;

                // Display whether the player won or lost
                if (areBricksAllGone.Equals(true))
                {
                    lblEndGame.Text = "You Win!!";
                    WinningMusic = new SoundPlayer(Properties.Resources.MarioWinning2);
                    WinningMusic.Play();
                }
                else
                {
                    lblEndGame.Text = "You Lose";
                    LoseMusic = new SoundPlayer(Properties.Resources.MarioLose);
                    LoseMusic.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during EndGame initialization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the Replay button click event
        private void btnReplay_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide(); // Hide the EndGame form
                Game game = new Game(gameLevel); // Create a new Game form with the current level
                game.Show(); // Show the new Game form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while replaying the game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the Exit button click event
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit(); // Close the game
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exiting the application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the Next Level button click event
        private void brnNextLevel_Click(object sender, EventArgs e)
        {
            try
            {
                gameLevel += 1; // Increment the level
                this.Hide(); // Hide the EndGame form
                Game game = new Game(gameLevel); // Create a new Game form with the next level
                game.Show(); // Show the new Game form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while advancing to the next level: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
